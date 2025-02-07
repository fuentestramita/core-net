﻿using System;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace Utilities
{
	static public class utils
	{
		static public void Send_Error(Exception ex)
		{
			string EMailUsuario = "photogranger@gmail.com";
			string MAIL_SENDER = ConfigurationManager.AppSettings["MAIL_SENDER"].ToString(); //System.Configuration.ConfigurationManager.ConnectionStrings[StringDB].ToString();
			string MAIL_PASS = ConfigurationManager.AppSettings["MAIL_PASS"].ToString(); //System.Configuration.ConfigurationManager.ConnectionStrings[StringDB].ToString();
			string MAIL_HOST = ConfigurationManager.AppSettings["MAIL_HOST"].ToString();
			string MAIL_PORT = ConfigurationManager.AppSettings["MAIL_PORT"].ToString();
			string MAIL_TARGETNAME = ConfigurationManager.AppSettings["MAIL_TARGETNAME"].ToString();


			SmtpClient client = new SmtpClient(MAIL_HOST, int.Parse(MAIL_PORT));
			client.EnableSsl = true;
			client.TargetName = MAIL_TARGETNAME;
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(MAIL_SENDER, MAIL_PASS);
			client.Port = 587;
			MailAddress from = new MailAddress(MAIL_SENDER, "CORE Tramita", System.Text.Encoding.Default);
			MailAddress to = new MailAddress(EMailUsuario);
			MailMessage message = new MailMessage(MAIL_SENDER, EMailUsuario);
			message.IsBodyHtml = true;
			message.BodyEncoding = System.Text.Encoding.Default;
			message.SubjectEncoding = System.Text.Encoding.Default;
			System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			message.Subject = "Hemos encontrado un error en Core";
			message.Body = "se ha producido un error en Core en tramita<br>" + ex.Message.Replace("\n", "<br>") +"<br><br>StackTrace:" + ex.StackTrace.Replace("\n", "<br>") + "</b></font><br><br><br>Atte.<br><br>Tramita S.P.A.";

			client.Send(message);

		}



		static public string getToken(string userId)
		{

			return "";
		}


		static public void setToken(string UsuarioID)
		{

		}

		static public Object isNull(string valor)
		{
			if (valor == null || valor == "")
				return DBNull.Value;
			else
				return valor;
		}


		static public string isNull(string valor, string Retorno)
		{
			if (valor == null || valor == "")
				return Retorno;
			else
				return valor;
		}


		static public object isNull(string valor, object Retorno)
		{
			if (valor == null || valor == "")
				return Retorno;
			else
				return valor;
		}

		// lectura archivo excel
		static public DataTable ReadExcelFileToDataTable(string filePath)
		{

			DataTable dataTable = new DataTable();

			// Configura el sistema de lectura para soportar codificación
			//System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

			using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
			{
				using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
				{
					// Convierte la hoja de cálculo en un DataSet
					var result = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
						{
							UseHeaderRow = true // Usa la primera fila como encabezados
						}
					});

					// Toma la primera hoja del archivo Excel
					dataTable = result.Tables[0];
					reader.Close();
				}
				stream.Close();
			}
			return dataTable;
		}

	}
}