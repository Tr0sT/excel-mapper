﻿using System;

namespace ExcelMapper.Pipeline.Items
{
    public class ChangeTypePipelineItem<T> : PipelineItem<T>
    {
        public override PipelineResult<T> TryMap(PipelineResult<T> item)
        {
            if (string.IsNullOrEmpty(item.Context.StringValue))
            {
                return item.MakeEmpty();
            }

            try
            {
                T value = (T)Convert.ChangeType(item.Context.StringValue, typeof(T));
                return item.MakeCompleted(value);
            }
            catch
            {
                return item.MakeInvalid();
            }
        }
    }
}