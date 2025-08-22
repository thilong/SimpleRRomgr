using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;

namespace RomgrApp.UI.Components;

public class CenteringWrapPanel : Panel
{
    protected override Size MeasureOverride(Size availableSize)
    {
        var children = Children;
        double x = 0, y = 0;
        double rowHeight = 0;
        double maxWidth = 0;

        foreach (var child in children)
        {
            child.Measure(availableSize);
            var desiredSize = child.DesiredSize;

            if (x + desiredSize.Width > availableSize.Width && x > 0)
            {
                x = 0;
                y += rowHeight;
                rowHeight = 0;
            }

            x += desiredSize.Width;
            rowHeight = Math.Max(rowHeight, desiredSize.Height);
            maxWidth = Math.Max(maxWidth, x);
        }

        return new Size(maxWidth, y + rowHeight);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        var children = Children;
        var rows = new List<List<Control>>();
        var currentRow = new List<Control>();
        double x = 0, y = 0;
        double rowHeight = 0;

        foreach (var child in children)
        {
            var desiredSize = child.DesiredSize;

            if (x + desiredSize.Width > finalSize.Width && x > 0)
            {
                rows.Add(currentRow);
                currentRow = new List<Control>();
                x = 0;
                y += rowHeight;
                rowHeight = 0;
            }

            currentRow.Add(child);
            x += desiredSize.Width;
            rowHeight = Math.Max(rowHeight, desiredSize.Height);
        }

        if (currentRow.Any()) rows.Add(currentRow);

        y = 0;
        double allLineStartX = -1;
        foreach (var row in rows)
        {
            double totalRowWidth = row.Sum(child => child.DesiredSize.Width);
            double startX = Math.Max(0, (finalSize.Width - totalRowWidth) / 2); // 居中计算

            if (allLineStartX < 0)
                allLineStartX = startX;

            x = startX;
            if (x > allLineStartX)
                x = allLineStartX;
            double currentRowHeight = row.Max(child => child.DesiredSize.Height);

            foreach (var child in row)
            {
                child.Arrange(new Rect(x, y, child.DesiredSize.Width, currentRowHeight));
                x += child.DesiredSize.Width;
            }

            y += currentRowHeight;
        }

        return finalSize;
    }
}