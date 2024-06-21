using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.CLASSLARIM
{
    internal class Backup
    {
       public static void yedekleme()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Veri Yedek Dosyası |0.bak";
            save.FileName = "KuryePera_MusteriKayit_Programi_" + DateTime.Now.ToShortDateString();
            if(save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if(File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }
                    var KuryePera=save.FileName;
                    string KuryePeraKaynak = Application.StartupPath + @"\KuryePeraVeriTabani.mdf";
                    using(var kurye = new KuryePeraVeriTabaniEntities())
                    {
                        var cmd = @"BACKUP DATABASE[" + KuryePeraKaynak + "] TO DISK = '" + KuryePera + "'";
                        kurye.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("TEBRİKLER YEDEKLEME TAMAMLANMIŞTIR.","TEBRİKLER",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                 
                }
            }
        }
    }
}
