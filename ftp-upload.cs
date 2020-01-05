 private void UploadFileToFTP(string source)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;
            try
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpPath + "/" +
                          Path.GetFileName(source));

                ftp.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;   
                ftp.Method = WebRequestMethods.Ftp.UploadFile;


                requestStream = ftp.GetRequestStream();
                fileStream = File.Open(source, FileMode.Open);
                byte[] buffer = new byte[1024];
                int bytesRead;
                while (true)
                {
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    requestStream.Write(buffer, 0, bytesRead);
                }
               
                requestStream.Close();
                uploadResponse = (FtpWebResponse)ftp.GetResponse();
            }
            catch (UriFormatException ex)
            {
               
            }
            catch (IOException ex)
            {
               
            }
            catch (WebException ex)
            {
               
            }
            finally
            {
                if (uploadResponse != null)
                    uploadResponse.Close();
                if (fileStream != null)
                    fileStream.Close();
                if (requestStream != null)
                    requestStream.Close();
            }
        }
