using System;
using System.Collections.Generic;

namespace AdventOfCode2015
{
    public class Day07
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day07input");

        public void Run()
        {
            //PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            Dictionary<string, ushort> wireValues = new Dictionary<string, ushort>();
            Dictionary<string, Instruction> instructions = new Dictionary<string, Instruction>();

            foreach (var item in input)
            {
                Instruction instruction = new Instruction();

                List<string> startingWires = ParseStartingWires(item);
                instruction.Input1 = startingWires[0];
                instruction.Input2 = startingWires.Count > 1 ? startingWires[1] : string.Empty;

                string bitwise = ParseBitwiseLogicGate(item);

                if (bitwise == "LSHIFT")
                {
                    instruction.instructionType = Instruction.InstructionType.LSHIFT;
                }
                else if (bitwise == "RSHIFT")
                {
                    instruction.instructionType = Instruction.InstructionType.RSHIFT;

                }
                else if (bitwise == "AND")
                {
                    instruction.instructionType = Instruction.InstructionType.AND;

                }
                else if (bitwise == "OR")
                {
                    instruction.instructionType = Instruction.InstructionType.OR;

                }
                else if (bitwise == "NOT")
                {
                    instruction.instructionType = Instruction.InstructionType.NOT;

                }
                else if (bitwise == "EQUALS")
                {
                    instruction.instructionType = Instruction.InstructionType.EQUALS;
                }

                instructions.Add(ParseFinalWire(item), instruction);
            }

            Console.WriteLine("a " + GetValue(instructions, wireValues, "a"));
            wireValues = new Dictionary<string, ushort>();
        }

        public void PartTwo()
        {
            Dictionary<string, ushort> wireValues = new Dictionary<string, ushort>();
            Dictionary<string, Instruction> instructions = new Dictionary<string, Instruction>();

            foreach (var item in input)
            {
                Instruction instruction = new Instruction();

                List<string> startingWires = ParseStartingWires(item);
                instruction.Input1 = startingWires[0];
                instruction.Input2 = startingWires.Count > 1 ? startingWires[1] : string.Empty;

                string bitwise = ParseBitwiseLogicGate(item);

                if (bitwise == "LSHIFT")
                {
                    instruction.instructionType = Instruction.InstructionType.LSHIFT;
                }
                else if (bitwise == "RSHIFT")
                {
                    instruction.instructionType = Instruction.InstructionType.RSHIFT;

                }
                else if (bitwise == "AND")
                {
                    instruction.instructionType = Instruction.InstructionType.AND;

                }
                else if (bitwise == "OR")
                {
                    instruction.instructionType = Instruction.InstructionType.OR;

                }
                else if (bitwise == "NOT")
                {
                    instruction.instructionType = Instruction.InstructionType.NOT;

                }
                else if (bitwise == "EQUALS")
                {
                    instruction.instructionType = Instruction.InstructionType.EQUALS;
                }

                instructions.Add(ParseFinalWire(item), instruction);
            }

            ushort a = GetValue(instructions, wireValues, "a");
            wireValues = new Dictionary<string, ushort>();
            wireValues["b"] = a;

            Console.WriteLine("a " + GetValue(instructions, wireValues, "a"));
        }

        public ushort GetValue(Dictionary<string, Instruction> instructions, Dictionary<string, ushort> wiresValues, string wire)
        {
            if (wiresValues.ContainsKey(wire)) return wiresValues[wire];

            Instruction curr = instructions[wire];
            ushort i = 0;


            if (curr.instructionType == Instruction.InstructionType.AND)
            {
                ushort val1 = 0;
                ushort val2 = 0;

                if (ushort.TryParse(curr.Input1, out i))
                {
                    val1 = i;
                }
                else
                {
                    val1 = GetValue(instructions, wiresValues, curr.Input1);
                }

                if (ushort.TryParse(curr.Input2, out i))
                {
                    val2 = i;
                }
                else
                {
                    val2 = GetValue(instructions, wiresValues, curr.Input2);
                }

                ushort ret = (ushort)((val1 & val2) & 0xFFFF);
                wiresValues.Add(wire, ret);

                return ret;
            }
            else if (curr.instructionType == Instruction.InstructionType.EQUALS)
            {

                if (ushort.TryParse(curr.Input1, out i))
                {
                    wiresValues.Add(wire, i);
                    return i;
                }

                return GetValue(instructions, wiresValues, curr.Input1);
            }
            else if (curr.instructionType == Instruction.InstructionType.LSHIFT)
            {
                ushort val1 = 0;
                ushort val2 = 0;

                if (ushort.TryParse(curr.Input1, out i))
                {
                    val1 = i;
                }
                else
                {
                    val1 = GetValue(instructions, wiresValues, curr.Input1);
                }

                if (ushort.TryParse(curr.Input2, out i))
                {
                    val2 = i;
                }
                else
                {
                    val2 = GetValue(instructions, wiresValues, curr.Input2);
                }

                

                ushort ret = (ushort)(((ushort)(val1 << val2)) & 0xFFFF);
                wiresValues.Add(wire, ret);
                return ret;
            }
            else if (curr.instructionType == Instruction.InstructionType.RSHIFT)
            {
                ushort val1 = 0;
                ushort val2 = 0;

                if (ushort.TryParse(curr.Input1, out i))
                {
                    val1 = i;
                }
                else
                {
                    val1 = GetValue(instructions, wiresValues, curr.Input1);
                }

                if (ushort.TryParse(curr.Input2, out i))
                {;
                    val2 = i;
                }
                else
                {
                    val2 = GetValue(instructions, wiresValues, curr.Input2);
                }

                return (ushort)(val1 >> val2);
            }
            else if (curr.instructionType == Instruction.InstructionType.OR)
            {
                ushort val1 = 0;
                ushort val2 = 0;

                if (ushort.TryParse(curr.Input1, out i))
                {
                    val1 = i;
                }
                else
                {
                    val1 = GetValue(instructions, wiresValues, curr.Input1);
                }

                if (ushort.TryParse(curr.Input2, out i))
                {
                    val2 = i;
                }
                else
                {
                    val2 = GetValue(instructions, wiresValues, curr.Input2);
                }

                ushort ret = (ushort)(((ushort)(val1 | val2)) & 0xFFFF);
                wiresValues.Add(wire, ret);
                return ret;
            }
            else /*if (curr.instructionType == Instruction.InstructionType.NOT)*/
            {
                ushort val1 = 0;

                if (ushort.TryParse(curr.Input1, out i))
                {
                    val1 = i;
                }
                else
                {
                    val1 = GetValue(instructions, wiresValues, curr.Input1);
                }

                ushort ret = (ushort)~val1;
                wiresValues.Add(wire, ret);
                return ret;
            }
        }

        private string ParseBitwiseLogicGate(string item)
        {
            string[] array = item.Split(' ');

            if (array.Length == 4)
            {
                //input is like "NOT ak -> al"
                return array[0];  
            } else if (array.Length == 3)
            {
                return "EQUALS";
            }

            //input is like "dz AND ef -> eh"
            return array[1];
        }

        private List<string> ParseStartingWires(string item)
        {
            List<string> startingWires = new List<string>();
            string[] array = item.Split(' ');
            

            if (array.Length == 4)
            {
                //input is like "NOT ak -> al"
                startingWires.Add(array[1]);
            }
            else if (array.Length > 4)
            {
                //jm LSHIFT 1 -> kg
                startingWires.Add(array[0]);
                startingWires.Add(array[2]);

            } else if (array.Length == 3)
            {
                //19138 -> b
                startingWires.Add(array[0]);
            }

            return startingWires;
        }

        private string ParseFinalWire(string item)
        {
            string[] array = item.Split(' ');

            return array[array.Length - 1];
        }
    }

    public class Instruction
    {
        public enum InstructionType
        {
            LSHIFT,
            RSHIFT,
            NOT,
            AND,
            OR,
            EQUALS
        }

        public InstructionType instructionType;

        public string Input1;
        public string Input2;
    }
}
