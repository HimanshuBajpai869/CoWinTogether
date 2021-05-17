using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidLibrary
{
    public class ReportEvaluationHelper
    {
        public string EvaluateTestScore(
            int rtPCRScore,
            int hrctTestScore,
            int coRadsScore,
            int crpScore,
            float dDimerScore,
            int oneL6Score,
            float nlrScore)
        {
            string result = "As per the evaluation, RTPCR is {0}, HRCT is {1}, CORADS is {2}, CRP is {3}, D-Dimer is {4}, 1LS is {5} and NLR is {6}.";

            string rtPCRResult = string.Empty;
            string hrctResult = string.Empty;
            string coradsResult = string.Empty;
            string crpResult = string.Empty;
            string ddimerResult = string.Empty;
            string oneLSResult = string.Empty;
            string nlrResult = string.Empty;

            if (rtPCRScore > 35)
            {
                rtPCRResult = "Serious";
            }
            else if (rtPCRScore >= 24 && rtPCRScore <= 35)
            {
                rtPCRResult = "Mild";
            }
            else
            {
                rtPCRResult = "Low";
            }

            if (hrctTestScore > 15)
            {
                hrctResult = "Serious";
            }
            else if (hrctTestScore >= 9 && hrctTestScore <= 15)
            {
                hrctResult = "Mild";
            }
            else
            {
                hrctResult = "Low";
            }

            if (coRadsScore >= 4)
            {
                coradsResult = "Serious";
            }
            else if (coRadsScore >= 2 && coRadsScore <= 3)
            {
                coradsResult = "Mild";
            }
            else
            {
                coradsResult = "Low";
            }

            if (crpScore > 100)
            {
                crpResult = "Serious";
            }
            else if (crpScore >= 26 && crpScore <= 100)
            {
                crpResult = "Mild";
            }
            else
            {
                crpResult = "Low";
            }

            if (dDimerScore > 1)
            {
                ddimerResult = "Serious";
            }
            else if (dDimerScore <= 1)
            {
                ddimerResult = "Mild";
            }
            else
            {
                ddimerResult = "Low";
            }

            if (oneL6Score >= 100)
            {
                oneLSResult = "Serious";
            }
            else if (oneL6Score >= 15 && oneL6Score <= 100)
            {
                oneLSResult = "Mild";
            }
            else
            {
                oneLSResult = "Low";
            }

            if (nlrScore >= 3.5)
            {
                nlrResult = "Serious";
            }
            else
            {
                nlrResult = "Mild";
            }

            return string
                .Format(
                result,
                rtPCRResult,
                hrctResult,
                coradsResult,
                crpResult,
                ddimerResult,
                oneLSResult,
                nlrResult
                );
        }
    }
}
