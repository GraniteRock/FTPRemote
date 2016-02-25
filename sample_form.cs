using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

// namespace 
namespace ftpRemote
{
    /// <summary>
    /// サンプルプログラムクラス
    /// </summary>
    public partial class sample_form : Form
    {
        /// <summary>
        /// サーバファイル情報の正規表現
        /// </summary>
        private string regex =
        @"^" +                          //# Start of line
        @"(?<dir>[\-ld])" +             //# File size          
        @"(?<permission>[\-rwx]{9})" +  //# Whitespace          \n
        @"\s+" +                        //# Whitespace          \n
        @"(?<filecode>\d+)" +
        @"\s+" +                        //# Whitespace          \n
        @"(?<owner>\w+)" +
        @"\s+" +                        //# Whitespace          \n
        @"(?<group>\w+)" +
        @"\s+" +                        //# Whitespace          \n
        @"(?<size>\d+)" +
        @"\s+" +                        //# Whitespace          \n
        @"(?<month>\w{3})" +            //# Month (3 letters)   \n
        @"\s+" +                        //# Whitespace          \n
        @"(?<day>\d{1,2})" +            //# Day (1 or 2 digits) \n
        @"\s+" +                        //# Whitespace          \n
        @"(?<timeyear>[\d:]{4,5})" +    //# Time or year        \n
        @"\s+" +                        //# Whitespace          \n
        @"(?<filename>(.*))" +          //# Filename            \n
        @"$";                           //# End of line

        // 接続ID/PASS
        private NetworkCredential m_cred = null;

        /// <summary>
        /// サーバのディレクトリパス
        /// </summary>
        private const string DEFAULT_DIRECTORY = "ftp://localhost/sftp-user/";
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public sample_form()
        {
            InitializeComponent();

            txtServerDirectory.Text = DEFAULT_DIRECTORY;
        }
        
        /// <summary>
        /// サーバのファイル読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadfile_Click(object sender, EventArgs e)
        {
            //リストの初期化
            ServerDirList.Items.Clear();
            try {
                // 接続ID/PASS
                NetworkCredential credent = getNetworkCredential();
                string directory = string.Empty;

                if (credent != null)
                {
                    directory = txtServerDirectory.Text;
                    GetServerDirData(directory, credent);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// ネットワーク認証情報の作成
        /// </summary>
        /// <returns>ネットワーク認証</returns>
        private NetworkCredential getNetworkCredential()
        {
            //ユーザ名.パスワードない場合は処理を抜ける
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text)) {
                MessageBox.Show(this,"ユーザ名もしくはパスワードが存在しません。","認証情報未入力",MessageBoxButtons.OK,MessageBoxIcon.Information );
                return null; 
            }
            // 認証情報を返す
            return new NetworkCredential(txtUser.Text, txtPass.Text);
        }
        
        /// <summary>
        /// サーバの指定FTPディレクトリの取得
        /// </summary>
        /// <param name="serverDir">サーバディレクトリ</param>
        /// <param name="credent">認証情報</param>
        private bool GetServerDirData(string serverDir,NetworkCredential credent)
        {
            bool dirDataGetResult = false ;
            //ファイル一覧を取得するディレクトリのURI
            Uri u = new Uri(serverDir);

            FtpWebRequest ftp = null;

            try
            {
                // FTPWebRequestの取得
                ftp = (FtpWebRequest)GetFtpWebRequest(credent, u, WebRequestMethods.Ftp.ListDirectoryDetails);

                //FtpWebResponseを取得
                using (FtpWebResponse ftpRes =
                    (FtpWebResponse)ftp.GetResponse())
                {
                    //FTPサーバーから送信されたデータを取得
                    using (System.IO.StreamReader sr =
                        new System.IO.StreamReader(ftpRes.GetResponseStream()))
                    {
                        while (true)
                        {
                            string line = sr.ReadLine();
                            if (line == null) break;

                            ServerDirList.Items.Add(line);
                        }

                        sr.Close();
                    }
                    //閉じる
                    ftpRes.Close();

                    dirDataGetResult = true;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
            }
            return dirDataGetResult;
        }
        /// <summary>
        /// ファイルストリーム取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileStream_Click(object sender, EventArgs e)
        {
            // 1件のときのみ取得可能
            if (ServerDirList.SelectedItems.Count == 1) {
                // 接続ID/PASS
                NetworkCredential credent = getNetworkCredential();
                string directory = string.Empty;

                if (credent != null)
                {
                    directory = txtServerDirectory.Text;
                    DataStreaming(directory, GetFileName((string)ServerDirList.SelectedItem), credent);
                }

            } else {
                MessageBox.Show("選択は1件のみ可能となっております。未選択、複数選択では処理できません。");
            }
        }


        /// <summary>
        /// サーバのファイル情報からファイル名を取得する
        /// </summary>
        /// <param name="serverList"></param>
        /// <returns></returns>
        private string GetFileName(string serverList)
        {
            var split = new Regex(regex).Match(serverList);
            string dir = split.Groups["dir"].ToString();
            string filename = split.Groups["filename"].ToString();
            bool isDirectory = !string.IsNullOrWhiteSpace(dir) && dir.Equals("d", StringComparison.OrdinalIgnoreCase);

            return filename;
        }

        /// <summary>
        /// ストリーミング処理の実施
        /// </summary>
        /// <param name="serverDir">サーバディレクトリ</param>
        /// <param name="filename">ファイル名</param>
        /// <param name="credent">認証情報</param>
        private void DataStreaming(string serverDir, string filename, NetworkCredential credent)
        {
            //ファイル一覧を取得するディレクトリのURI
            Uri u = new Uri(serverDir + filename);
            FtpWebRequest ftpReq = null;
            try
            {
                txtCsvDetail.Text = "";

                // FTPWebRequestの取得
                ftpReq = (FtpWebRequest)GetFtpWebRequest(credent, u, WebRequestMethods.Ftp.DownloadFile);

                using (WebResponse res = ftpReq.GetResponse())
                using (StreamReader st = new StreamReader(res.GetResponseStream(),
                    System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    string results = st.ReadToEnd();
                    st.Close();

                    txtCsvDetail.Text = results;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }

        }

        /// <summary>
        /// FTPRequestを構築
        /// </summary>
        /// <param name="credent"></param>
        /// <returns></returns>
        private FtpWebRequest GetFtpWebRequest(
            NetworkCredential credent,
            Uri accesspath,
            string methodType)
        {
            //FtpWebRequestの作成
            FtpWebRequest ftpReq = null;

            try
            {
                //FtpWebRequestの作成
                ftpReq = (FtpWebRequest)
                    WebRequest.Create(accesspath);

                //ログインユーザー名とパスワードを設定
                ftpReq.Credentials = credent;

                //処理タイプの設定
                ftpReq.Method = methodType;
                //要求の完了後に接続を閉じる
                ftpReq.KeepAlive = false;
                //PASSIVEモードを無効にする
                ftpReq.UsePassive = false;
                //Binaryモードを無効
                ftpReq.UseBinary = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }

            return ftpReq;
        }

    }
}
