using System;
using System.Collections.Generic;
using System.Collections;
using ProjectCaseStudy.Data;

namespace ProjectCaseStudy
{
    public abstract class TheoryData : IEnumerable<object[]>
    {
        public readonly List<object[]> data = new();

        protected void AddRow(params object[] values)
        {
            data.Add(values);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public abstract class TestDataBase<T> : TheoryData
    {
        protected abstract JsonIO<T> IO { get; }
        protected abstract string FilePath { get; }

        public TestDataBase()
        {
            var data = IO.LoadFile(FilePath, 1000);
            if (data == null) return;

            for (int i = 0; i < data.Count; i++)
            {
                Add(data[i]);
            }
        }
        public void Add(T data)
        {
            if (data == null) return;
            AddRow(data);
        }
    }

    public class TestDataJobTitle : TestDataBase<JobTitleData>
    {
        private readonly JobTitleIO _io = new();

        protected override JsonIO<JobTitleData> IO => _io;

        protected override string FilePath => "Data\\data.json";

    }

    public class TestDataBuzz : TestDataBase<BuzzPost>
    {
        private readonly BuzzPostIO _io = new();
        protected override JsonIO<BuzzPost> IO => _io;

        protected override string FilePath => "Data\\dataBuzz.json";
    }

    public class TestDataEmployee : TestDataBase<Employee>
    {
        private readonly EmployeeIO _io = new();
        protected override JsonIO<Employee> IO => _io;
        protected override string FilePath => "Data\\dataEmployee0.json";

    }
    public class TestDataEmployee2 : TestDataEmployee
    {
        protected override string FilePath => "Data\\dataEmployee1.json";
    }

    public class TestDataAccount : TestDataBase<Account>
    {
        private readonly AccountIO _io = new();
        protected override JsonIO<Account> IO => _io;

        protected override string FilePath => "Data\\dataAccount.json";
    }

    public class TestBugReportData: TestDataBase<BugReportData>
    {
        private readonly BugReportIO _io = new();
        protected override JsonIO<BugReportData> IO => _io;

        protected override string FilePath => "Data\\bugReport.json";

    }
}
