using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Org.BouncyCastle.Asn1.Cms;
using Renci.SshNet.Messages.Connection;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace Sorozatok
{
    class Connection
    {
        private static MySqlConnection con = new MySqlConnection("SERVER=localhost;UID=root;PWD=;DATABASE=dat");

        public static void Connect()
        {
            try
            {
                con.Open();
            }
            catch(MySqlException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public static void Insert(TextBox t1,PasswordBox t2)
        {
            if (t1.Text.Length > 0 && t2.Password.Length > 0)
            {
                Connect();
                string command = String.Format("INSERT INTO users(id,username,password) VALUES(NULL,'{0}','{1}')", t1.Text, Encrypt.Titkosit(t2));
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres regisztráció!");
                con.Close();
            }
            else
                MessageBox.Show("Nem maradhat üres mező!", "Hibaüzenet");
        }

        public static bool Login(TextBox t1,PasswordBox t2)
        {
            Connect();
            string sql = String.Format("SELECT username,password FROM users WHERE username = '{0}' AND password = '{1}'", t1.Text, Encrypt.Titkosit(t2));
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();
            read.Read();
            if (!read.HasRows)
            {
                MessageBox.Show("A felhasználónév vagy jelszó helytelen!","Hibaüzenet");
                read.Close();
                con.Close();
                return false;
            }
            else
            {
                read.Close();
                con.Close();
                return true;
            }
        }

        public static bool FillListS(ref List<Sorozat> l,string user)
        {
            Connect();
            string sql = String.Format("SELECT name,akt_evad,akt_resz,img FROM series INNER JOIN users ON series.userid = users.id WHERE users.username = '{0}' ORDER BY name",user);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();

            l.Clear();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    // Class feltöltése
                    l.Add(new Sorozat(read.GetString(0), read.GetInt32(1), read.GetInt32(2), read.GetString(3)));
                }
                read.Close();
                con.Close();
                return true;
                
            }
            else
            {
                read.Close();
                con.Close();
                return false;
            }
           
        }

        public static void InsertSeries(string username,string name,string akt_evad,string akt_resz,string path)
        {
            Connect();
            string sql = "";
            MySqlCommand cmd;
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Nem lehet név nélkül elmenteni!", "Figyelmeztetés");
                con.Close();
            }
            else
            {
                if (!String.IsNullOrEmpty(akt_evad) && !String.IsNullOrEmpty(akt_resz))
                {
                    sql = String.Format("INSERT INTO series(id,userid,name,akt_evad,akt_resz,img) VALUES(NULL,(SELECT id FROM users WHERE username = '{0}'),'{1}','{2}','{3}','{4}')", username, name, int.Parse(akt_evad), int.Parse(akt_resz), path);
                    cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else if (String.IsNullOrEmpty(akt_evad) && !String.IsNullOrEmpty(akt_resz))
                {
                    DialogResult dialog = MessageBox.Show("Biztosan így menti le?\n Alapértelmezetten 1.évad"+ akt_resz + ".rész lesz elmentve!", "Figyelmeztetés", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        sql = String.Format("INSERT INTO series(id,userid,name,akt_evad,akt_resz,img) VALUES(NULL,(SELECT id FROM users WHERE username = '{0}'),'{1}','1','{2}','{3}')", username, name,int.Parse(akt_resz), path);
                        cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (!String.IsNullOrEmpty(akt_evad) && String.IsNullOrEmpty(akt_resz))
                {
                    DialogResult dialog = MessageBox.Show("Biztosan így menti le?\n Alapértelmezetten " + akt_evad + "." +  "évad 1.rész lesz elmentve!", "Figyelmeztetés", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        sql = String.Format("INSERT INTO series(id,userid,name,akt_evad,akt_resz,img) VALUES(NULL,(SELECT id FROM users WHERE username = '{0}'),'{1}','{2}','1','{3}')", username, name, int.Parse(akt_evad), path) ;
                        cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Biztosan így menti le?\n Alapértelmezetten " + akt_evad + "." + "évad 1.rész lesz elmentve!", "Figyelmeztetés", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        sql = String.Format("INSERT INTO series(id,userid,name,akt_evad,akt_resz,img) VALUES(NULL,(SELECT id FROM users WHERE username = '{0}'),'{1}','1','1','{2}')", username, name, path);
                        cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        public static void EditSeries(string actualname,string name,string akt_evad,string akt_resz,string path)
        {
            Connect();
            string sql = "";
            MySqlCommand cmd;
            bool nev = false;
            bool akt_evadb = false;
            bool akt_reszb = false;
            if(name.Length > 0)
                nev = true;
            if (akt_evad.Length > 0)
                akt_evadb = true;
            if (akt_resz.Length > 0)
                akt_reszb = true;

            if(nev && akt_evadb && akt_reszb)
            {
                sql = String.Format("UPDATE series SET name = '{0}',akt_resz = '{1}',akt_evad = '{2}',img = '{3}' WHERE name = '{4}'", name, int.Parse(akt_evad), int.Parse(akt_resz),path, actualname);
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres frissítés!");
                con.Close();
            }

            if(akt_evadb && akt_reszb && !nev)
            {
                sql = String.Format("UPDATE series SET akt_evad = '{0}',akt_resz = '{1}',img = '{2}' WHERE name = '{3}'", int.Parse(akt_evad),int.Parse(akt_resz),path,actualname);
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres frissítés!");
                con.Close();
            }

            if(akt_reszb && !akt_evadb && !nev)
            {
                sql = String.Format("UPDATE series SET akt_resz = '{0}',img = '{1}' WHERE name = '{2}'", int.Parse(akt_resz),path, actualname);
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres frissítés!");
                con.Close();
            }

            if(akt_evadb && !akt_reszb && !nev)
            {
                sql = String.Format("UPDATE series SET akt_evad = '{0}',img = '{1}' WHERE name = '{2}'", int.Parse(akt_evad),path, actualname);
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres frissítés!");
                con.Close();
            }

            if(nev && !akt_evadb && !akt_reszb)
            {
                sql = String.Format("UPDATE series SET name = '{0}',img = '{1}' WHERE name = '{2}'", name,path, actualname);
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres frissítés!");
                con.Close();
            }

            if(!nev && !akt_evadb && !akt_reszb)
            {
                MessageBox.Show("Legalább egy mezőt ki kell tölteni!");
                con.Close();
            }
        }

        public static bool DeleteSeries(string name)
        {
            Connect();
            string sql = String.Format("DELETE FROM series WHERE name = '{0}'", name);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            DialogResult dialog = MessageBox.Show("Biztosan törölni szeretné a sorozatot?", "Sorozat törlése",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sorozat törölve!");
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public static void InsertType(string t,string user)
        {
            Connect();
            string sql = "SELECT type FROM users";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader read = cmd.ExecuteReader();
            
            string sql2;
            MySqlCommand cmd2;
            if (read.HasRows)
            {
                read.Close();
                sql2 = String.Format("UPDATE users SET type = '{0}' WHERE username = '{1}'", t, user);
                cmd2 = new MySqlCommand(sql2, con);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                read.Close();
                sql2 = String.Format("INSERT INTO users(type) VALUES('{0}') WHERE username = '{1}'", t, user);
                cmd2 = new MySqlCommand(sql2, con);
                cmd2.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void InsertMovie(string user,string name,string path)
        {
            Connect();
            string sql = String.Format("INSERT INTO movies(id,userid,name,path) VALUES(NULL,(SELECT id FROM users WHERE username = '{0}'),'{1}','{2}')", user, name, path);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool FillListM(ref List<Movies> l, string user)
        {
            Connect();
            string sql = String.Format("SELECT name,path FROM movies INNER JOIN users ON movies.userid = users.id WHERE users.username = '{0}'", user);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    l.Add(new Movies(read.GetString(0), read.GetString(1)));
                    
                }
                read.Close();
                con.Close();
                return true;
            }
            else
            {
                read.Close();
                con.Close();
                return false;
            }
        }

        public static void InsertFavS(string name)
        {
            string sql = String.Format("INSERT INTO series(kedvenc) VALUES('{0}')", 1);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

        }
    }
}
