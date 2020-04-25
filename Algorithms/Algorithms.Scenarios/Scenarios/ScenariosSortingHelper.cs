using Live.Core;
using Live.Core.Rendering;
using Live.Core.Scripting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using imgui = ImGuiNET.ImGui;
using System;
using System.Linq;
using ImGuiNET;
using Live.Core.Annotations;

namespace Algorithms.Scenarios
{
    public class ScenariosSortingHelper : ScenarioSingleRun
    {
        BarChartRenderer renderer = new BarChartRenderer();
        int[] values = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6, 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

        public ScenariosSortingHelper()
        {
        }

        protected override void Run()
        {
            var sortingHelper = new SortingHelper();
            sortingHelper.QuickSort(values, 0, values.Length - 1);
        }

        protected override void VisDraw(TimeInterval time)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            DrawUserInterface(time, () => renderer.RenderBarChart(time, values));
        }
    }
    public class ScenariosSortingHelper2 : ScenarioSingleRun
    {
        BarChartRenderer renderer = new BarChartRenderer();
        int[] values = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6, 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

        public ScenariosSortingHelper2()
        {
        }

        protected override void Run()
        {
            var sortingHelper = new SortingHelper();
            sortingHelper.QuickSort(values, 0, values.Length - 1);
        }

        protected override void VisDraw(TimeInterval time)
        {
            GraphicsDevice.Clear(Color.Yellow);
            DrawUserInterface(time, () => renderer.RenderBarChart(time, values));
        }
    }

    [ReloadableClass]
    public class BarChartRenderer
    { 
        //private int count = 0;

        public void RenderBarChart(TimeInterval time, int[] values)
        {
            //count++;

            if (imgui.Begin("Bar Chart"))
            {
                var xPositions = values.Select((v, i) => i * 31).ToList();

                int swapStartIndex = Vis.Context.Get("SwapStart", -1);
                int swapEndIndex = Vis.Context.Get("SwapEnd", -1);
                int pivotIndex = Vis.Context.Get("Pivot", -1);
                int rangeStartIndex = Vis.Context.Get("RangeStart", -1);
                int rangeEndIndex = Vis.Context.Get("RangeEnd", -1);

                float barChartHeight = imgui.GetWindowHeight() - 40;

                //imgui.Text(count.ToString());
                imgui.Text($"Pivot Index: {pivotIndex}, Left Index: {rangeStartIndex}, Right Index: {rangeEndIndex}");

                void DrawBar(int i)
                {
                    var value = values[i];
                    int length = value * 8;

                    float xPos = xPositions[i];

                    imgui.PushStyleColor(ImGuiCol.Text, Color.Black.PackedValue);

                    var percent = MathHelper.Clamp((float)time.Total.TotalSeconds, 0, 1);
                    float yCurveDelta = 0;

                    void SetVariables(int destIndex, Color brush)
                    {
                        imgui.PushStyleColor(ImGuiCol.Button, brush.PackedValue);

                        // animate bar moving to dest
                        if (destIndex != -1)
                        {
                            xPos = MathHelper.Lerp(xPos, xPositions[destIndex], percent);
                            yCurveDelta = (float)Math.Sin(MathHelper.ToRadians(180 * percent)) * 50;
                        }
                    }


                    if (i == swapStartIndex)
                    {
                        SetVariables(swapEndIndex, Color.Green);
                    }
                    else if (i == swapEndIndex)
                    {
                        SetVariables(swapStartIndex, Color.Red);
                    }
                    else if (i == pivotIndex)
                    {
                        SetVariables(-1, Color.Yellow);
                    }
                    else if (i >= rangeStartIndex & i <= rangeEndIndex)
                    {
                        imgui.PushStyleColor(ImGuiCol.Button, Color.Silver.PackedValue);
                    }
                    else
                    {
                        imgui.PushStyleColor(ImGuiCol.Button, Color.DimGray.PackedValue);
                    }

                    var area = new SharpDX.RectangleF(
                        xPos,
                        barChartHeight - length - yCurveDelta,
                        30,
                        length
                        );

                    if (length < 0)
                    {
                        area.Y = barChartHeight - yCurveDelta;
                        area.Height = -length;
                    }

                    imgui.SetCursorPos(new System.Numerics.Vector2(area.X, area.Y));
                    imgui.Button(value.ToString(), new System.Numerics.Vector2(area.Width, area.Height));

                    imgui.PopStyleColor();
                    imgui.PopStyleColor();
                }

                for (int i = 0; i < values.Length; i++)
                {
                    DrawBar(i);
                }

                if (swapStartIndex != -1)
                {
                    DrawBar(swapStartIndex);
                }

                if (swapEndIndex != -1)
                {
                    DrawBar(swapEndIndex);
                }

                if (pivotIndex != -1)
                {
                    DrawBar(pivotIndex);
                }

                imgui.End();
            }
        }
    }
}
