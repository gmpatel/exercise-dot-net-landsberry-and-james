======================================================================

Motive : Extensible code/application 

======================================================================

Core Projects
  AnnualLeave 
  AnnualLeave.Logging
  AnnualLeave.MicrosoftContainer

Code Executor/Tester Projects
  AnnualLeave.UnitTests

Department Wise Custom Rules Extender Projects
  AnnualLeave.CustomLeaveValidators

Repository Extender Projects
  AnnualLeave.CustomRepositories

Critical IoC Files
  \AnnualLeave.MicrosoftContainer\UnityBootstrapper.cs
  \AnnualLeave.UnitTests\App.config

Critical Tests Executing Files
  \AnnualLeave.UnitTests\EngineeringHumanResourseDepartmentTests.cs
  \AnnualLeave.UnitTests\ProductionHumanResourseDepartmentTests.cs
  \AnnualLeave.UnitTests\SalesHumanResourseDepartmentTests.cs

======================================================================

Important Notes/Points (Please Read):

======================================================================

AnnualLeave.CustomLeaveValidators & AnnualLeave.CustomRepositories projects are using AnnualLeave project to implement ILeaveValidator and IRepository interfaces respectively.

AnnualLeave.CustomLeaveValidators & AnnualLeave.CustomRepositories projects are not referenced directly to any projects. They are independent projects can be develop and extend by any one. They are referenced/configured using Unit Configuration Section

In order to run Unit Tests successfully, you must build AnnualLeave.CustomLeaveValidators & AnnualLeave.CustomRepositories projects manually one by one OR can use Rebuild Solution option. There are Post Build Events configured on AnnualLeave.CustomLeaveValidators & AnnualLeave.CustomRepositories projects which copies AnnualLeave.CustomLeaveValidators.dll & AnnualLeave.CustomRepositories.dll into \AnnualLeave.UnitTests\bin\Debug OR \AnnualLeave.UnitTests\bin\Release folders on each successful build. Unity configuration then reference/configure them for an appropriate injections.

Please make sure that AnnualLeave.CustomLeaveValidators.dll & AnnualLeave.CustomRepositories.dll are present in \AnnualLeave.UnitTests\bin\Debug AND/OR \AnnualLeave.UnitTests\bin\Release directories if Tests are failing or throwing errors or exceptions.

Please check \AnnualLeave.UnitTests\App.config file for detailed IoC injection configuration for different HR Departments. To add support of new HR Departments, you can create new project which implements ILeaveValidator and add correct configuration in to \AnnualLeave.UnitTests\App.config OR appropriate .config file. And that's it, there will not be any other code change require.

======================================================================