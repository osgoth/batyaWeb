using System;
using System.Diagnostics;
using System.Net;

namespace batyaNet
{
    class Handler
    {
        bool RedirectStandardOutput;
        bool UseShellExecute;
        bool CreateNoWindow;

        public Handler ()
        {
            this.RedirectStandardOutput = true;
            this.CreateNoWindow = true;
            this.UseShellExecute = false;
        }

        public Handler (bool RedirectStandardOutput, bool CreateNoWindow, bool UseShellExecute)
        {
            this.RedirectStandardOutput = RedirectStandardOutput;
            this.CreateNoWindow = CreateNoWindow;
            this.UseShellExecute = UseShellExecute;

            string[] chain = { "INPUT", "FORWARD", "OUTPUT" };

            foreach (string ch in chain)
            {
                Process proc = new Process ()
                {
                    StartInfo = new ProcessStartInfo
                    {
                    FileName = "iptables",
                    Arguments = $"-A {ch} -s localost -j ACCEPT",
                    RedirectStandardOutput = this.RedirectStandardOutput,
                    UseShellExecute = this.UseShellExecute,
                    CreateNoWindow = this.CreateNoWindow
                    }
                };
                proc.Start ();
            }

        }

        public void Block (string site)
        {

            //get ip address of a site
            string BlockAddr = Dns.GetHostAddresses (site) [0].ToString ();

            //initialize process  'iptables -A INPUT -s site.site -j DROP'

            Process proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "iptables",
                Arguments = $"-A INPUT -s localhost -j ACCEPT",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };
            proc.Start ();

            proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "iptables",
                Arguments = $"-A INPUT -s {BlockAddr} -j DROP",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };

            //start process

            proc.Start ();

            //read output of a command

            System.Console.WriteLine (proc.StandardOutput.ReadToEnd ());

        }

        public void Unblock (string site)
        {

            string ip = Dns.GetHostAddresses (site) [0].ToString ();

            string[] arr = {
                $"-A INPUT -s {ip} -j ACCEPT",
                "-P INPUT DROP"
            };

            foreach (string str in arr)
            {
                Process proc = new Process ()
                {
                    StartInfo = new ProcessStartInfo
                    {
                    FileName = "iptables",
                    Arguments = str,
                    RedirectStandardOutput = this.RedirectStandardOutput,
                    UseShellExecute = this.UseShellExecute,
                    CreateNoWindow = this.CreateNoWindow
                    }
                };

                proc.Start ();
            }

        }

        public void BlockAll ()
        {

            Process proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "iptables",
                Arguments = $"-A INPUT -s localhost -j ACCEPT",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };
            proc.Start ();

            proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "iptables",
                Arguments = $"-P INPUT DROP",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };
            proc.Start ();

        }

        public void UnblockAll ()
        {
            string[] chains = { "INPUT", "FORWARD", "OUTPUT" };
            foreach (string ch in chains)
            {
                new Process ()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "iptables",
                            Arguments = $"-F {ch}",
                            RedirectStandardOutput = this.RedirectStandardOutput,
                            UseShellExecute = this.UseShellExecute,
                            CreateNoWindow = this.CreateNoWindow
                    }
                }.Start ();
            }

            foreach (string ch in chains)
            {
                new Process ()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "iptables",
                            Arguments = $"-P {ch} ACCEPT",
                            RedirectStandardOutput = this.RedirectStandardOutput,
                            UseShellExecute = this.UseShellExecute,
                            CreateNoWindow = this.CreateNoWindow
                    }
                }.Start ();
            }

        }

        public string GetStatus ()
        {
            Process proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "iptables",
                Arguments = $"-L --line-numbers",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };
            proc.Start ();

            return
            proc.StandardOutput.ReadToEnd ();
        }

        public string GetIP ()
        {
            Process proc = new Process ()
            {
                StartInfo = new ProcessStartInfo
                {
                FileName = "hostname",
                Arguments = "-I",
                RedirectStandardOutput = this.RedirectStandardOutput,
                UseShellExecute = this.UseShellExecute,
                CreateNoWindow = this.CreateNoWindow
                }
            };
            proc.Start ();
            return proc.StandardOutput.ReadToEnd ();
        }

    }
}

/*

iptables -A INPUT -s google.com -j ACCEPT
iptables -A OUTPUT -d google.com -j ACCEPT
iptables -P INPUT DROP
iptables -P OUTPUT DROP

*/
