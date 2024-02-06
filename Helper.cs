using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class Helper
    {
        public static T Input<T>()
        {
            string n = "";
            try
            {
                n = Console.ReadLine();
                if (typeof(T)==typeof(string))
                {
                    if (n.Length <= 12)
                    {
                        return (T)Convert.ChangeType(n, typeof(T));
                    }
                    else
                    {
                        Console.WriteLine("Enter 6 to 12-digit vehicle Number");
                        return Input<T>();  
                    } 
                }
                else
                {
                    T a = (T)Convert.ChangeType(n, typeof(T));
                    if (Comparer<T>.Default.Compare(a, default(T)) < 0)
                    {
                        throw new Exception();
                    }
                    return (T)Convert.ChangeType(n, typeof(T));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter Number");
                return Input<T>();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please Enter smaller Number");
                return Input<T>();
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter Positive Number");
                return Input<T>();
            }
            
        }
    }
}
