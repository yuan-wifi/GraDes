using System;
using System.Threading;
using System.Windows.Forms;
namespace test
{
    public partial class WaittingWindow : Form
    {
        
        DataBase db = new DataBase();
        private int pici;
        private object turn;
        private int invcode;

        public WaittingWindow(int pici, int turn, int invcode)
        {
            this.turn = turn;
            this.pici = pici;
            this.invcode = invcode;
            InitializeComponent();
        }

        private void WaittingWindow_Shown(Object sender, EventArgs e)
        {
            //设置线程
            Control.CheckForIllegalCrossThreadCalls = false;//防止出现 线程间操作无效 的错误
            Thread t = new Thread(wait);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void wait()
        {
            while (true)
            {
                int nosubmit = db.Selectissubmit();
                if (nosubmit == 0)
                {
                    if((pici+1) > (int)turn)
                    {
                        this.Hide();
                        MessageBox.Show("非常感谢！本次投票已经全部结束！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Environment.Exit(0);
                        break;
                    }
                    else
                    {
                        VoteWindow vote = new VoteWindow(pici + 1, db.Selectturn(), invcode);
                        this.Hide();
                        vote.ShowDialog();
                        Application.ExitThread();
                        break;
                    }
                    
                }
                else
                {

                    Thread.Sleep(3000);
                }
            }
        }
    }
}
