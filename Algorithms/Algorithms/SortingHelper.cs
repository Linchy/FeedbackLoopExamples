using Live.Core;
using Live.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Todo: add vis calls, re-ordering a bar chart as it goes
    /// </summary>
    public class SortingHelper
    {
        public void QuickSort(int[] values, int left, int right)
        {
            QuickSortInner(values, left, right);
            Vis.Run(ctx =>
            {
                ctx.ClearState()
                   .Pause();
            });
        }

        private void QuickSortInner(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSortInner(arr, start, i - 1);
                QuickSortInner(arr, i + 1, end);
            }
        }

        private int Partition(int[] arr, int start, int end)
        {
            int p = arr[end];
            int i = start - 1;

            Vis.Run(ctx =>
            {
                ctx.Set("Pivot", end)
                   .Set("RangeStart", start)
                   .Set("RangeEnd", end);
            });

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    SwapIfNotEqual(arr, i, j);
                }
            }

            SwapIfNotEqual(arr, i+1, end);

            return i + 1;
        }

        private void SwapIfNotEqual(int[] arr, int i, int j)
        {
            if (arr[i] != arr[j])
            {
                Vis.Run(ctx =>
                {
                    ctx.Set("SwapStart", i)
                       .Set("SwapEnd", j)
                       .Pause();
                });

                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
}