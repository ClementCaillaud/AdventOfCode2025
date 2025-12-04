using Common.Application;
using Common.Constants;
using Day04_PrintingDepartment;

Application.ProcessPart(new Part1(InputPath.Example), InputType.EXAMPLE);
Application.ProcessPart(new Part1(InputPath.Input), InputType.INPUT);
Application.ProcessPart(new Part2(InputPath.Example), InputType.EXAMPLE);
Application.ProcessPart(new Part2(InputPath.Input), InputType.INPUT);