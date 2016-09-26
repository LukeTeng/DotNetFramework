using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service.UtilityTools
{
    public class UtilityTools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetIEnumeratorAccount<T>(IEnumerable<T> source)
        {
            try
            {
                int result = 0;
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                        result++;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

    }
}
