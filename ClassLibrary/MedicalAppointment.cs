﻿/*
 * 
 * <copyright file = "MedicalAppointment"   Developer: João Veloso </copyright>
 * <author>jngveloso</author>
 * <email>jngveloso@gmail.com</email>
 * <date>4/24/2020 3:54:23 PM</date>
 * <description></description>
 * 
 */




using System;
using System.Threading;

namespace HospitalBarcelos
{
    [Serializable]
    /// <summary>
    /// Classe das consultas
    /// </summary>
    public class MedicalAppointment
    {
        #region Member Variables

        private int idMedicalAppointment;
        private string typeOfMedical;
        protected private int codStaff;
        protected private int codPatient;
        protected DateTime date;

        private static int globalID; 



        #endregion

        #region Constructors
        /// <summary>
        /// Construtor por defeito.
        /// </summary>
        public MedicalAppointment()
        {
            idMedicalAppointment = 0;
            typeOfMedical = "";
            date = DateTime.UtcNow;
            codStaff = 0;
            codPatient = 0;
        }


        /// <summary>
        /// Construtor com parametros
        /// </summary>
        /// <param name="typeOfMedical"></param>
        /// <param name="codStaff"></param>
        /// <param name="codPatient"></param>
        /// <param name="date"></param>
        public MedicalAppointment(string typeOfMedical, int codStaff, int codPatient, DateTime date)
        {
            this.idMedicalAppointment = Interlocked.Increment(ref globalID);
            this.typeOfMedical = typeOfMedical;
            this.date = date;

            this.codStaff = codStaff;
            this.codPatient = codPatient;

        }



        #endregion

        #region Properties

        public int IdMedicalAppointment { get => idMedicalAppointment; set => idMedicalAppointment = value; }

        public string TypeOfMedical { get => typeOfMedical; set => typeOfMedical = value; }

        public int CodStaff { get => codStaff; set => codStaff = value; }

        public int CodPatient { get => codPatient; set => codPatient = value; }

        public DateTime Date { get => date; set => date = value; }

        #endregion

        #region Functions


        /// <summary>
        /// cria nova consulta
        /// </summary>
        /// <param name="medicalAppointment"></param>
        /// <param name="patient"></param>
        /// <param name="medic"></param>
        /// <returns></returns>

        public MedicalAppointment CreateNewMedicalAppointment(MedicalAppointment medicalAppointment, Patient patient, Staff medic)
        {
            int aux;
            aux = patient.IdPatient;
            this.idMedicalAppointment = Interlocked.Increment(ref globalID);
            Console.WriteLine("Diga o tipo de consulta:\n");
            medicalAppointment.typeOfMedical = Console.ReadLine();
            medicalAppointment.codPatient = patient.IdPatient;
            medicalAppointment.codStaff = medic.IdStaff;
            patient.Screen = Patient.Screening.ND;
            patient.GetAttended = Patient.Attended.Yes;
            patient.RemovePatient(patient, aux);

            

            return medicalAppointment;

        }
        public MedicalAppointment FindMedicalAppointmentById(MedicalAppointment medicalAppointment, int idMedicalAppointment)
        {
            if (medicalAppointment != null && medicalAppointment.idMedicalAppointment == idMedicalAppointment)
            {
                return medicalAppointment;
            }
            return null;
        }




        /// <summary>
        /// Funcao que imprime a classe.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.idMedicalAppointment} - {this.typeOfMedical} - {this.codStaff} - {this.codPatient}";
        }





        #endregion

        #region Enums
        #endregion
    }
}