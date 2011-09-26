﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D3Sharp.Net.Game.Messages.ACD
{
    public class ACDEnterKnownMessage : GameMessage
    {
        public int Field0;
        public int /* sno */ Field1;
        public int Field2;
        public int Field3;
        public WorldLocationMessageData Field4;
        public InventoryLocationMessageData Field5;
        public GBHandle Field6;
        public int Field7;
        public int Field8;
        public int Field9;
        public byte Field10;
        public int /* sno */? Field11;
        public int? Field12;
        public int? Field13;

        public ACDEnterKnownMessage():base(Opcodes.ACDEnterKnownMessage){}

        public ACDEnterKnownMessage(string[] Data, int f2):base(Opcodes.ACDEnterKnownMessage)
        {
            Id = 0x003B;
            Field0 = int.Parse(Data[2]);
            Field1 = int.Parse(Data[3]);
            Field2 = int.Parse(Data[4]);
            Field3 = int.Parse(Data[5]);

            Field4 = null;

            if (int.Parse(Data[0]) > 0)
                Field4 = new WorldLocationMessageData()
                {
                    Field0 = float.Parse(Data[6], System.Globalization.CultureInfo.InvariantCulture),
                    Field1 = new PRTransform()
                    {
                        Field0 = new Quaternion()
                        {
                            Field0 = float.Parse(Data[10], System.Globalization.CultureInfo.InvariantCulture),
                            Field1 = new Vector3D()
                            {
                                Field0 = float.Parse(Data[7], System.Globalization.CultureInfo.InvariantCulture),
                                Field1 = float.Parse(Data[8], System.Globalization.CultureInfo.InvariantCulture),
                                Field2 = float.Parse(Data[9], System.Globalization.CultureInfo.InvariantCulture),
                            },
                        },
                        Field1 = new Vector3D()
                        {
                            Field0 = float.Parse(Data[11], System.Globalization.CultureInfo.InvariantCulture),
                            Field1 = float.Parse(Data[12], System.Globalization.CultureInfo.InvariantCulture),
                            Field2 = float.Parse(Data[13], System.Globalization.CultureInfo.InvariantCulture),
                        },
                    },
                    Field2 = f2, //=int.Parse(Data[14]),
                };

            Field5 = null;
            if (int.Parse(Data[1]) > 0)
            {
                Field5 = new InventoryLocationMessageData()
                {
                    Field0 = int.Parse(Data[15]),
                    Field1 = int.Parse(Data[16]),
                    Field2 = new IVector2D()
                    {
                        Field0 = int.Parse(Data[17]),
                        Field1 = int.Parse(Data[18]),
                    }
                };
            }

            Field6 = new GBHandle()
            {
                Field0 = int.Parse(Data[19]),
                Field1 = int.Parse(Data[20]),
            };
            Field7 = int.Parse(Data[21]);
            Field8 = int.Parse(Data[22]);
            Field9 = int.Parse(Data[23]);
            Field10 = byte.Parse(Data[24]);
        }

        public override void Handle(GameClient client)
        {
            throw new NotImplementedException();
        }

        public override void Parse(GameBitBuffer buffer)
        {
            throw new NotImplementedException();
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(32, Field0);
            buffer.WriteInt(32, Field1);
            buffer.WriteInt(5, Field2);
            buffer.WriteInt(2, Field3 - (-1));
            buffer.WriteBool(Field4 != null);
            if (Field4 != null)
            {
                Field4.Encode(buffer);
            }
            buffer.WriteBool(Field5 != null);
            if (Field5 != null)
            {
                Field5.Encode(buffer);
            }
            Field6.Encode(buffer);
            buffer.WriteInt(32, Field7);
            buffer.WriteInt(32, Field8);
            buffer.WriteInt(4, Field9 - (-1));
            buffer.WriteInt(8, Field10);
            buffer.WriteBool(Field11.HasValue);
            if (Field11.HasValue)
            {
                buffer.WriteInt(32, Field11.Value);
            }
            buffer.WriteBool(Field12.HasValue);
            if (Field12.HasValue)
            {
                buffer.WriteInt(32, Field12.Value);
            }
            buffer.WriteBool(Field13.HasValue);
            if (Field13.HasValue)
            {
                buffer.WriteInt(32, Field13.Value);
            }
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("ACDEnterKnownMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("Field0: 0x" + Field0.ToString("X8") + " (" + Field0 + ")");
            b.Append(' ', pad); b.AppendLine("Field1: 0x" + Field1.ToString("X8"));
            b.Append(' ', pad); b.AppendLine("Field2: 0x" + Field2.ToString("X8") + " (" + Field2 + ")");
            b.Append(' ', pad); b.AppendLine("Field3: 0x" + Field3.ToString("X8") + " (" + Field3 + ")");
            if (Field4 != null)
            {
                Field4.AsText(b, pad);
            }
            if (Field5 != null)
            {
                Field5.AsText(b, pad);
            }
            Field6.AsText(b, pad);
            b.Append(' ', pad); b.AppendLine("Field7: 0x" + Field7.ToString("X8") + " (" + Field7 + ")");
            b.Append(' ', pad); b.AppendLine("Field8: 0x" + Field8.ToString("X8") + " (" + Field8 + ")");
            b.Append(' ', pad); b.AppendLine("Field9: 0x" + Field9.ToString("X8") + " (" + Field9 + ")");
            b.Append(' ', pad); b.AppendLine("Field10: 0x" + Field10.ToString("X2"));
            if (Field11.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field11.Value: 0x" + Field11.Value.ToString("X8"));
            }
            if (Field12.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field12.Value: 0x" + Field12.Value.ToString("X8") + " (" + Field12.Value + ")");
            }
            if (Field13.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field13.Value: 0x" + Field13.Value.ToString("X8") + " (" + Field13.Value + ")");
            }
            b.Append(' ', --pad);
            b.AppendLine("}");
        }
    }
}
