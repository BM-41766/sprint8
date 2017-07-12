using facebook1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace facebook1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
         // return View("Index");
             return View("AdminHome");
            //  return View("Facebook_Flipkrt");

        }
        ServiceReference1.Service1Client sr1 = new ServiceReference1.Service1Client();
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(ModelClass1 mc, string loginid, string path, string cmd, HttpPostedFileBase img1, string X_emailaddress, string X_paswrd, string X_frstname, string X_srname, string X_emailadress, string X_pawrd, string proflepic, string X_day, string X_month, string X_year, string X_gendr)
        {

            //    DateTime d1 = DateTime.Now;
            // string d2= sr1.suspend(loginid);
            // DateTime dt = Convert.ToDateTime(d2);

            //  string differnc = (d1-dt).TotalDays();
            if (cmd == "Login")
            {
                string tempvar;
                string X_loginid;
                string fname;
                string surname;
                string profpic;
                string status;


                string msg = sr1.login(X_emailaddress, X_paswrd);

                if (msg.Contains("Responce code:200"))
                {
                    sr1.getlogindetails(X_emailaddress, X_paswrd, out X_loginid, out fname, out surname, out profpic);
                    sr1.getstatus(X_loginid, out status);
                    ViewData["status"] = status;
                    ViewData["mainloginid"] = X_loginid;
                    ViewData["firstname"] = fname;
                    ViewData["lastname"] = surname;
                    ViewData["profilepic"] = profpic;
                    return View("Homepage");
                }
                return Content("<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>");
                //return View(mc);

            }




            if (cmd == "create an account")
            {
                if (sr1.ban_check(X_emailadress))
                {
                    string str = "it's a deleted account";
                    return Content("<script language='javascript' type='text/javascript'>alert('" + str + "');</script>");

                }

                int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int year = Convert.ToInt32(mc.X_year);
                int age = currentYear - year;
                if (age >= 13)
                {
                    if (img1 != null && img1.ContentLength > 0)
                    {
                        path = Path.Combine(Server.MapPath("~/profileimgs"),
                                                  Path.GetFileName(img1.FileName));
                        img1.SaveAs(path);
                        //string msgg = mc.signup(path);
                        DateTime DT_dob = Convert.ToDateTime(X_day + "/" + X_month + "/" + X_year);
                        string msgg = sr1.signupMethod(X_frstname, X_srname, X_emailadress, X_paswrd, proflepic, DT_dob, X_gendr);
                    }
                    //return Content("<script language='javascript'type='text/javascript'>alert('" +  + "');</script>");
                    return View("Vpage");
                }
               
            }
             return null;

            

        }




        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Homepage(ModelClass1 mc, string X_firstname, string cmd1,string btn1)
        {
            if (cmd1 == "search")
            {
                //string m1;
                //m1 = sr1.searching(X_firstname);
                //SqlConnection CONN = new SqlConnection("Data Source=DESKTOP-GGK19TE\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
                //CONN.Open();
                //SqlCommand CMD = CONN.CreateCommand();
                //CMD.CommandText = "select loginid,firstname,surname,profilepic,emailaddress from Userloggin where firstname like'" + X_firstname + "'";
                //SqlDataReader sdr = CMD.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);

                //List<friendserch> lst = new List<friendserch>();
                //foreach(DataRow row in dt.Rows)
                //{
                //   friendserch lst1=new friendserch()
                //   {
                //       loginid = row["loginid"].ToString(),
                //       X_firstname = row["firstname"].ToString(),
                //       X_surname = row["surname"].ToString(),
                //       profilepic = row["profilepic"].ToString(),
                //       emailaddress=row["emailaddress"].ToString()

                //   };
                //   lst.Add(lst1);
                //}
                //return View("Homepage", lst);
                return View("Homepage");

            }
             
          
            return null;

        }
        public void fcall()
        {

            //Response.Redirect(Url.Action("Facebook_Flipkrt", "Home"));
                //return View("Facebook_Flipkrt");
             RedirectToAction("Facebook_Flipkrt", "Home");
            
        }


        public string getfriend(string name)
        {
            string str = sr1.searching(name);
            return str;
        }
        public void addfrnd(string receiverid, string senderid)
        {
            sr1.addfriend(receiverid, senderid);

        }

        public string frndaprove(string reciverid1, string senderid1)
        {
            string str1 = sr1.frndapproval(reciverid1, senderid1);
            return str1;
        }
        public void confirm(string reciverid, string senderid)
        {
            sr1.confrm(reciverid, senderid);
        }
        public void delete(string reciverid, string senderid)
        {
            sr1.delete(reciverid, senderid);
        }
        public string frndsearch(string loginid)
        {
            string str = sr1.frndserch(loginid);
            return str;
        }
        public void unfriend(string reciverid, string senderid)
        {
            sr1.unfrnd(reciverid, senderid);
        }
        public string postingstatus(string loginid, string posting)
        {
            string str = sr1.posting(loginid, posting);
            return str;
        }
        public String postimage()
        {
            string totable = "";
            string imgname = "";
            string path = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pict = System.Web.HttpContext.Current.Request.Files["fileImg"];
                if (pict.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pict.FileName);
                    var ext = Path.GetExtension(pict.FileName);
                    imgname = Guid.NewGuid().ToString();
                    var contpath = Server.MapPath("/postimage/") + imgname + ext;
                    imgname = imgname + ext;
                    totable = "/postimage/" + imgname;
                    path = contpath;
                    pict.SaveAs(path);
                }
            }
            return JsonConvert.SerializeObject(totable);


        }
        public string postingimage(string logginid, string postimg, string postheder)
        {
            string str = sr1.postingimge(logginid, postimg, postheder);
            return str;
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult advertpage(string cmd, string X_frstname, string X_srname, string X_emailadress, string X_pawrd, string X_day, string X_month, string X_year, string X_gendr)
        {
            if (cmd == "create an account")
            {
                //ServiceReference1.Service1Client sc1 = new ServiceReference1.Service1Client();
                DateTime DT_dob = Convert.ToDateTime(X_day + "/" + X_month + "/" + X_year);
                sr1.signupadvert(X_frstname, X_srname, X_emailadress, X_pawrd, DT_dob, X_gendr);
            }
            return View("");

        }

        public string Userprofile1()
        {
            string str = sr1.userprofile();
            return str;
        }
        public string editUserprofile1(string loginid)
        {
            string str = sr1.edituserprofile(loginid);
            return str;
        }
        public void admin_delete(string loginid, string emailaddress)
        {
            sr1.admindelete(loginid, emailaddress);
        }
        public string edit_userprofile(string logginid)
        {
            string str = sr1.edit_user(logginid);
            return str;
        }
        public void aply_advertisr(string logginid)
        {
            sr1.aply_advertiser(logginid);
        }
        public string Aproval_pending(string loginid)
        {
            string str = sr1.Apprval_Pending(loginid);
            return str;
        }
        public void Suspend(string loginid)
        {
            sr1.Admin_suspend(loginid);
        }
        public void approv(string loginid)
        {
            sr1.Approve(loginid);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Homepage1(string btn1)
        {
            string tempvar;
            string img;
            if (btn1 == "fkrt")
            {
                sr1.flpkrt(out img);
                ViewData["img"] =img;

                return View("Facebook_Flipkrt");
            }
            return null;
        }
        public string imge()
        {
           string str= sr1.flpkrtimg();
           return str;
        }
        public  void fun1()
        {

        }
        public string products1()
        {
            string str=sr1.product_details();
            return str;
        }

        public string customers(string customer_id)
        {
            string str = sr1.customer_details();
            return str;
        }

     public string order()
        {
            string str = sr1.order_details();
            return str;
        }
        public void f1()
     {

     }
        public void f2()
        {

        }
        public void f3()
        {

        }
    }


}
  

