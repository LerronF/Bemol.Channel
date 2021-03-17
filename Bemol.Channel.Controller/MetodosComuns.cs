﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bemol.Channel.Controller
{
    public class MetodosComuns
    {
        public static string Format(string field, string mask)
        {
            MaskedTextProvider mtp = new MaskedTextProvider(mask);

            mtp.Set(field);

            return mtp.ToString();
        }

        #region -- Checa o CPF
        public static bool CheckCPF(string sNumero)
        {
            String Numero = sNumero;
            bool igual = true;

            if (Numero.Length != 11)
            {
                return false;
            }

            for (int i = 1; i < 11 && igual; i++)
            {
                if (Numero[i] != Numero[0])
                {
                    igual = false;
                }
            }

            if (igual || Numero == "12345678909")
            {
                return false;
            }

            int[] Num = new int[11];

            for (int i = 0; i < 11; i++)
            {
                Num[i] = int.Parse(Numero[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * Num[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (Num[9] != 0)
                {
                    return false;
                }
            }

            else if (Num[9] != (11 - resultado))
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * Num[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (Num[10] != 0)
                {
                    return false;
                }
            }
            else if (Num[10] != (11 - resultado))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Formata CPF
        public static string CPFFormat(string cpf)
        {
            return MetodosComuns.Format(cpf, @"000,000,000-00");
        }
        #endregion

        #region Formata CEP
        public static string CEPFormat(string cep)
        {
            return MetodosComuns.Format(cep, @"00000-000");
        }
        #endregion
    }
}
