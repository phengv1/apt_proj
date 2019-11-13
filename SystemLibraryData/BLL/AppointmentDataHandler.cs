using System.Collections.Generic;

namespace SystemLibraryData
{
    public class AppointmentDataHandler
    {
        AppointmentData appointment = new AppointmentData();
        public List<Appointment> GetAppointmentData()
        {

            return appointment.GetAppointmentData();
        }

        public bool MakeNewAppointment(Appointment apt)
        {
            return appointment.MakeAppointmentData(apt);
        }

        public bool UpdateChargeStatus(Appointment apt)
        {
            return appointment.UpdateChargeStatusData(apt);
        }

        public bool UpdateAptStatus(Appointment apt)
        {
            return appointment.UpdateAptStatusData(apt);
        }

        public List<Fee> GetDoctorFee(int id)
        {

            return appointment.GetDocFee(id);
        }
    }
}