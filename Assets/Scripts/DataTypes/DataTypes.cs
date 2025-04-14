using System;
using UnityEngine;
namespace DataTypes
{
    public class DataTypes : MonoBehaviour
    {
        private void Start()
        {
            ValueTypeSample valueTypeSample = new ValueTypeSample();

            AssignValueExample();
            AssignDefaultValueExample();
            StringPassExample();
            StringBehavior();

            ClassReferenceExample();
            ClassReferenceExample2();
            ClassReferenceExample3();

            StringExample();
        }


        private void AssignValueExample()
        {
            int assignedValue = 10;
            var sampleStruct = new SampleStruct();

            sampleStruct.sampleInt = assignedValue;
            sampleStruct.sampleInt = 9;

            Debug.Log("<color=green>assignedValue</color> = " + assignedValue);
        }

        private void AssignDefaultValueExample()
        {
            var structA = new SampleStruct();
            Debug.Log("structA.sampleInt = " + structA.sampleInt);


            if (structA.sampleClass == null)
            {
                Debug.Log("structA.sampleClass is null");
            }
        }

        private void StringPassExample()
        {
            string str = "Utku";
            ChangeString(str);

            Debug.Log("str = " + str);
            ChangeStringRef(ref str);

            Debug.Log("str = " + str);
        }

        private void ChangeString(string str)
        {
            str = "Sever";
        }

        private void ChangeStringRef(ref string str)
        {
            str = "Sever";
        }

        private void StringBehavior()
        {
            string sentence = "Sample sentence";
            CompleteSentence(ref sentence);

            Debug.Log("<color=green>" + sentence + "</color>");
        }

        //since we have reference we can change
        private void CompleteSentence(ref string refString)
        {
            refString += ".";
        }

        private void ClassReferenceExample()
        {
            var sampleClassA = new SampleClass();
            var sampleClassB = new SampleClass();

            sampleClassA.sampleInt = 1001;
            sampleClassB = sampleClassA;
            sampleClassB.sampleInt = 1002;

            Debug.Log(sampleClassA.sampleInt);
        }

        private void ClassReferenceExample2()
        {
            var sampleClassA = new SampleClass();
            var sampleClassB = new SampleClass();
            sampleClassA.sampleInt = 1001;
            sampleClassB.sampleInt = 1002;
            sampleClassB = sampleClassA;

            Debug.Log(sampleClassB.sampleInt);
        }

        private void ClassReferenceExample3()
        {
            var sampleClassA = new SampleStruct();
            var sampleClassB = new SampleClass();
            sampleClassA.sampleInt = 1001;
            sampleClassB.sampleInt = 1002;
            sampleClassA.sampleClass = new SampleClass();
            sampleClassA.sampleClass.sampleInt = 1003;
            sampleClassB = sampleClassA.sampleClass;
            sampleClassB.sampleInt = 1004;

            Debug.Log(sampleClassA.sampleInt + " " + sampleClassB.sampleInt);
        }

        private static void StringExample()
        {
            string str1 = new string("Utku");
            string str2 = new string("Utku");
            string str3 = "Utku";
            string str4 = "Utku";


            if (str1 == str2)
            {
                Debug.Log("str1 is equal to str2");
            }

            if (str2 == str3)
            {
                Debug.Log("str2 is equal to str3");
            }

            if (str3 == str4)
            {
                Debug.Log("str3 is equal to str4");
            }
        }

        public class ValueTypeSample
        {
            byte sampleByte;
            short sampleShort;
            ushort sampleUnsignedShort;
            int sampleInt;
            uint sampleUnsignedInt;
            long sampleLong;
            ulong sampleUnsignedLong;

            float sampleFloat;
            decimal sampleDecimal;
            double sampleDouble;

            bool sampleBool;

            public ValueTypeSample()
            {
                AnalyzeByte();
                AnalyzeShort();
                AnalyzeUnsignedShort();
                AnalyzeInteger();
                AnalyzeUnsignedInteger();
                AnalyzeLong();
                AnalyzeUnsignedLong();

                AnalyzeFloat();
                AnalyzeDecimal();
                AnalyzeDouble();

                AnalyzeBool();

                IncrementOfAValue();
            }

            private void AnalyzeByte()
            {
                Debug.Log("default value of byte = " + sampleByte);
                Debug.Log("size of byte = " + sizeof(byte));
                Debug.Log("max value of byte = " + byte.MaxValue);
                Debug.Log("min value of byte = " + byte.MinValue);
                Debug.Log("Type of byte = " + sampleByte.GetType());

                AddBlankLog();
            }

            private void AnalyzeShort()
            {
                Debug.Log("default value of short = " + sampleShort);
                Debug.Log("size of short = " + sizeof(short));
                Debug.Log("max value of short = " + short.MaxValue);
                Debug.Log("min value of short = " + short.MinValue);
                Debug.Log("Type of short = " + sampleShort.GetType());

                AddBlankLog();
            }

            private void AnalyzeUnsignedShort()
            {
                Debug.Log("default value of unsigned short = " + sampleUnsignedShort);
                Debug.Log("size of unsigned short = " + sizeof(ushort));
                Debug.Log("max value of unsigned short = " + ushort.MaxValue);
                Debug.Log("min value of unsigned short = " + ushort.MinValue);
                Debug.Log("Type of unsigned short = " + sampleUnsignedShort.GetType());

                AddBlankLog();
            }

            private void AnalyzeInteger()
            {
                Debug.Log("default value of integer = " + sampleInt);
                Debug.Log("size of integer = " + sizeof(int));
                Debug.Log("max value of integer = " + int.MaxValue);
                Debug.Log("min value of integer = " + int.MinValue);
                Debug.Log("Type of integer = " + sampleInt.GetType());

                AddBlankLog();
            }

            private void AnalyzeUnsignedInteger()
            {
                Debug.Log("default value of unsigned integer = " + sampleUnsignedInt);
                Debug.Log("size of unsigned integer = " + sizeof(uint));
                Debug.Log("max value of unsigned integer = " + uint.MaxValue);
                Debug.Log("min value of unsigned integer = " + uint.MinValue);
                Debug.Log("Type of unsigned integer = " + sampleUnsignedInt.GetType());

                AddBlankLog();
            }

            private void AnalyzeLong()
            {
                Debug.Log("default value of long = " + sampleLong);
                Debug.Log("size of long = " + sizeof(long));
                Debug.Log("max value of long = " + long.MaxValue);
                Debug.Log("min value of long = " + long.MinValue);
                Debug.Log("Type of long = " + sampleLong.GetType());

                AddBlankLog();
            }

            private void AnalyzeUnsignedLong()
            {
                Debug.Log("default value of unsigned long = " + sampleUnsignedLong);
                Debug.Log("size of unsigned long = " + sizeof(ulong));
                Debug.Log("max value of unsigned long = " + ulong.MaxValue);
                Debug.Log("min value of unsigned long = " + ulong.MinValue);
                Debug.Log("Type of unsigned long = " + sampleUnsignedLong.GetType());

                AddBlankLog();
            }

            private void AnalyzeFloat()
            {
                Debug.Log("default value of float = " + sampleFloat);
                Debug.Log("size of float = " + sizeof(float));
                Debug.Log("max value of float = " + float.MaxValue);
                Debug.Log("min value of float = " + float.MinValue);
                Debug.Log("Type of float = " + sampleFloat.GetType());

                AddBlankLog();
            }

            private void AnalyzeDecimal()
            {
                Debug.Log("default value of decimal = " + sampleDecimal);
                Debug.Log("size of decimal = " + sizeof(decimal));
                Debug.Log("max value of decimal = " + decimal.MaxValue);
                Debug.Log("min value of decimal = " + decimal.MinValue);
                Debug.Log("Type of decimal = " + sampleDecimal.GetType());

                AddBlankLog();
            }

            private void AnalyzeDouble()
            {
                Debug.Log("default value of double = " + sampleDouble);
                Debug.Log("size of double = " + sizeof(double));
                Debug.Log("max value of double = " + double.MaxValue);
                Debug.Log("min value of double = " + double.MinValue);
                Debug.Log("Type of double = " + sampleDouble.GetType());

                AddBlankLog();
            }

            private void AnalyzeBool()
            {
                Debug.Log("default value of bool = " + sampleBool);
                Debug.Log("size of bool = " + sizeof(bool));
                Debug.Log("Type of bool = " + sampleBool.GetType());

                AddBlankLog();
            }

            private void AddBlankLog()
            {
                Debug.Log(Environment.NewLine);
            }

            private void IncrementOfAValue()
            {
                int a = 10;
                IncreaseInt(a);
                Debug.Log("<color=red>a</color> = " + a);
                IncreaseInt(ref a);
                Debug.Log("<color=red>a</color> = " + a);
            }

            private void IncreaseInt(int a)
            {
                Debug.Log("IncreaseInt(int a) called");
                a++;
            }

            private void IncreaseInt(ref int a)
            {
                Debug.Log("IncreaseInt(ref int a) called");
                a++;
            }
        }

        public struct SampleStruct
        {
            public int sampleInt; //value type
            public float sampleFloat;
            public string sampleString;
            public SampleClass sampleClass; // reference type
        }

        public class SampleClass
        {
            public int sampleInt;
            public int sampleFloat;
            public int sampleString;
        }
    }
}