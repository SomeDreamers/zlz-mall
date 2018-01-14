//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Utils/EmailUtil 
//  创建人:                     kencery     
//  创建时间:                   2016/10/30 16:51:43
//  网站:                       http://www.chuxinm.com
//==============================================================

using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Pls.Utils
{
    /// <summary>
    /// 邮箱发送封装公共方法
    /// </summary>
    public static class EmailUtil
    {
        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <param name="email">收件人邮箱地址</param>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="mailConfig">邮箱配置尸体</param>
        /// <param name="textpart">内容格式(默认为p:plain)，不写为html</param>
        /// <returns></returns>
        public static bool Send(string email, string subject, string message, SendMailConfig mailConfig, string textpart = "p")
        {
            textpart = textpart == "p" ? "plain" : "html";
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(mailConfig.SendServerName, mailConfig.SendServerAddress));
                emailMessage.To.Add(new MailboxAddress(email, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(textpart) { Text = message };

                using (var client = new SmtpClient())
                {
                    client.Connect(mailConfig.ServerAddress, mailConfig.ServerPort, true);
                    client.Authenticate(mailConfig.SendServerAddress, mailConfig.SendServerPwd);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="email">收件人邮箱地址</param>
        /// <param name="subject">标题</param>
        /// <param name="message">内容</param>
        /// <param name="mailConfig">邮箱配置尸体</param>
        /// <param name="textpart">内容格式(默认为p:plain)，不写为html</param>
        /// <returns></returns>
        public static async Task<bool> SendEmailAsync(string email, string subject, string message, SendMailConfig mailConfig, string textpart = "p")
        {
            textpart = textpart == "p" ? "plain" : "html";
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(mailConfig.SendServerName, mailConfig.SendServerAddress));
                emailMessage.To.Add(new MailboxAddress(email, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(textpart) { Text = message };

                using (var client = new SmtpClient())
                {
                    //SSL协议发送
                    await client.ConnectAsync(mailConfig.ServerAddress, mailConfig.ServerPort, true).ConfigureAwait(false);
                    //非SSL协议发送  端口号不一致
                    //await client.ConnectAsync(mailConfig.ServerAddress, mailConfig.ServerPort, SecureSocketOptions.None).ConfigureAwait(false);
                    await client.AuthenticateAsync(mailConfig.SendServerAddress, mailConfig.SendServerPwd);
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}