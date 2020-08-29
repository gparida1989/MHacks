using Mhacks.Models;
using System.Collections;
using System.Collections.Generic;

namespace Mhacks.Xunit.Runner
{
    public abstract class TheoryData : IEnumerable<object[]>
    {
        readonly List<object[]> data = new List<object[]>();

        protected void AddRow(params object[] values)
        {
            data.Add(values);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class TheoryData<T1, T2> : TheoryData
    {
        public void Add(T1 p1, T2 p2)
        {
            AddRow(p1, p2);
        }
    }

    public class CartTestData : TheoryData<CartItem[], double>
    {
        public CartTestData()
        {
            //Add(TestScenarios.Scenario1.CartItems, TestScenarios.Scenario1.ExpectedTotalAmount);
            Add(TestScenarios.Scenario2.CartItems, TestScenarios.Scenario2.ExpectedTotalAmount);
            //Add(TestScenarios.Scenario3.CartItems, TestScenarios.Scenario3.ExpectedTotalAmount);

        }
    }
}
