using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Read
                Console.WriteLine("Querying for an org");
                var orgs = db.SALPGroups.ToList();

                foreach (SALPGroup thisOrg in orgs)
                {
                    using (FileStream fs = new FileStream(thisOrg.OrganizationName + ".html", FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.WriteLine("<header><div class='header'><h2>" + thisOrg.Level1Category + "</h2></div><nav><a href='#'>Home</a><a href='#'>Student Groups</a><a href='#'>Jobs/Volunteer</a><a href='#'>Services</a><a href='#'>Deals</a><a href='#'>Fun!</a></nav></header>");
                            
                            w.WriteLine("<div class='organization " + thisOrg.Level1Category.Replace(" ", String.Empty) + " " + thisOrg.Level2Category.Replace(" ", String.Empty) + "'>" + Environment.NewLine);

                            w.WriteLine("<H1>" + thisOrg.OrganizationName + "</H1>" + Environment.NewLine);

                            w.WriteLine("<p>" + thisOrg.Description + "</p>" + Environment.NewLine);

                            w.WriteLine("<button href='" + thisOrg.PSUConnectPage + "'>Connect</button>" + Environment.NewLine);

                            w.WriteLine("</div>" + Environment.NewLine);
                        }
                    }

                    Console.WriteLine("HTML template complete for  " + thisOrg.OrganizationName);

                }
            }

        }
    }
}
