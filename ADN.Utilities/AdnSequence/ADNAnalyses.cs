using ADN.Domain.CustomEntities;
using ADN.Domain.Interfaces.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADN.Utilities.AdnSequence
{
    public class AdnAnalyses : IAdnAnalyses
    {

        private readonly ConfigurationAdn _configurationAdn;

        public AdnAnalyses(IOptions<ConfigurationAdn> options)
        {
            _configurationAdn = options.Value;
        }

        private int CountMatrixHorizontalExists(string[] matrix, string adn)
        {
            int result = 0;
            foreach (var item in matrix)
            {
                result += item.Contains(adn) ? 1 : 0;
            }

            return result;
        }

        private int CountMatrixVerticalExists(string[] matrix, string adn)
        {
            int result = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                StringBuilder sequence = new StringBuilder();
                for (int j = 0; j < matrix.Length; j++)
                {
                    sequence.Append(matrix[j][i]);
                }

                if (sequence.ToString().Contains(adn))
                {
                    result++;
                }
            }

            return result;
        }

        private int CountMatrixDiagonalExists(string[] matrix, string adn)
        {
            int result = 0;

            ///validate unnecessary paths
            int lengthDifference = matrix.Length - adn.Length;

            ///ocurrencias en la diagonal inferior y diagonal central, de arriba para abajo
            for (int i = lengthDifference; i >= 0; i--)
            {
                StringBuilder sequenceToAnalyzeSB = new StringBuilder();
                for (int j = 0; j < matrix.Length - i; j++)
                {
                    sequenceToAnalyzeSB.Append(matrix[i + j][j]);
                }

                if (sequenceToAnalyzeSB.ToString().Contains(adn))
                {
                    result++;
                }
            }

            ///occurrences in the upper diagonal, from top to bottom
            for (int i = 1; i <= lengthDifference; i++)
            {
                StringBuilder sequenceToAnalyzeSB = new StringBuilder();
                for (int j = 0; j < matrix.Length - i; j++)
                {
                    sequenceToAnalyzeSB.Append(matrix[j][i + j]);
                }

                if (sequenceToAnalyzeSB.ToString().Contains(adn))
                {
                    result++;
                }
            }

            ///occurrences in the lower diagonal and central diagonal, from bottom to top
            for (int i = lengthDifference + 1; i < matrix.Length; i++)
            {
                StringBuilder sequenceToAnalyzeSB = new StringBuilder();
                for (int j = 0; j <= i; j++)
                {
                    sequenceToAnalyzeSB.Append(matrix[i - j][j]);
                }

                if (sequenceToAnalyzeSB.ToString().Contains(adn))
                {
                    result++;
                }
            }

            ///occurrences in the upper diagonal, from bottom to top
            for (int i = 0; i < lengthDifference; i++)
            {
                StringBuilder sequenceToAnalyzeSB = new StringBuilder();

                for (int j = i + 1; j < matrix.Length; j++)
                {
                    sequenceToAnalyzeSB.Append(matrix[matrix.Length - j + i][j]);
                }

                if (sequenceToAnalyzeSB.ToString().Contains(adn))
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Check if the matrix is square
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private bool IsSquare(string[] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return false;
            }

            foreach (var element in matrix)
            {
                if (matrix.Length != element.Length)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> IsClon(string[] matrix)
        {
            if (!IsValidMatrix(matrix))
            {
                throw new Exception("matrix invalid");
            }

            int quantity = 0;
            foreach (var quantitySearch in _configurationAdn.Search)
            {
                quantity += Search(matrix, quantitySearch.Sequence);
            }

            bool isclon = quantity > _configurationAdn.Min;

            return isclon;
        }

        private int Search(string[] matrix, string adn)
        {
            int result = 0;

            result += CountMatrixHorizontalExists(matrix, adn);
            result += CountMatrixVerticalExists(matrix, adn);
            result += CountMatrixDiagonalExists(matrix, adn);

            return result;
        }

        public string StringMatrix(string[] matrix)
        {
            if (matrix != null && matrix.Length > 0)
            {
                StringBuilder result = new StringBuilder();
                foreach (var item in matrix)
                {
                    result.Append(item + "-");
                }

                string stringresult = result.ToString();
                return stringresult.Substring(0, stringresult.Length - 1);
            }

            return string.Empty;
        }

        public bool IsValidMatrix(string[] matrix)
        {
            bool valid = true;
            if (matrix != null)
            {
                foreach (var item in matrix)
                {
                    if (!Regex.Match(item, _configurationAdn.AdnSequence, RegexOptions.IgnoreCase).Success)
                    {
                        valid = false;
                    }
                }

                if (!IsSquare(matrix))
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }

            return valid;
        }

    }
}
