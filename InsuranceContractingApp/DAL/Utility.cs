using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingApp.DAL
{
    public class QuickUnionWeighted
    {
        private int[] masterArray;
        private int[] sizeOfSubTree;
        private int count;

        public QuickUnionWeighted(int length)
        {
            masterArray = new int[length];
            sizeOfSubTree = new int[length];

            for (int i = 0; i < length; i++)
            {
                masterArray[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            int rootValue = FindRoot(p);
            int rootValueq = FindRoot(q);
            if (rootValue == rootValueq) return;

            if (sizeOfSubTree[rootValue] < sizeOfSubTree[rootValueq])
            {
                masterArray[rootValue] = rootValueq;
                sizeOfSubTree[rootValueq] += sizeOfSubTree[rootValue];
            }
            else
            {
                masterArray[rootValueq] = rootValue;
                sizeOfSubTree[rootValue] += sizeOfSubTree[rootValueq];
            }
        }

        private int FindRoot(int rootOf)
        {
            int rootElement = rootOf;
            while (rootElement != masterArray[rootElement])
            {
                rootElement = masterArray[rootElement];
            }
            return rootElement;
        }

        public bool IsConnected(int p, int q)
        {
            return FindRoot(p) == FindRoot(q);
        }

    }

}
