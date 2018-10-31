using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class BranchesContainer
    {
        public const int maxAmountOfBranches = 100;
        public Branch[] branches;
        public int Count { get; private set; }
        public BranchesContainer()
        {
            branches = new Branch[maxAmountOfBranches];
        }
        public void AddBranch(Branch branch)
        {
            branches[Count] = branch;
            Count++;
        }
        public Branch GetBranch(int index)
        {
            return branches[index];
        }
    }
}
