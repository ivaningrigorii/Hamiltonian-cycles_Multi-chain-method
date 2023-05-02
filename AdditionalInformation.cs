using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursWork_Ivanin_MainFile_CSharp
{
    static class AdditionalInformation
    {
        public static void AboutCreator()
        {
            MessageBox.Show("Проект разработал Иванин Григорий", "О разработчике");
        }

        public static void AboutProgram()
        {
            MessageBox.Show("Программа предназначена для нахождения\nГамильтоновых циклов", "О программе");
        }

        public static void AboutMath()
        {
            MessageBox.Show("Для поиска циклов применяется\nмультицепной метод", "О математике");
        }
    }
}
