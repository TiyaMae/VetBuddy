#nullable disable

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class FileManager
{
    //----------------- PATIENT -------------------------
    public List<Patient> LoadPatients()
    {
        List<Patient> patients = new List<Patient>();

        if (!File.Exists("Data\\patients.txt")) return patients;

        using (StreamReader reader = new StreamReader("Data\\patients.txt")){
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] data = line.Split(',');

                Patient patient = new Patient(
                    int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    data[3],
                    data[4],
                    data[5],
                    data[6]
                    );
                patients.Add(patient);
            }
        }

        return patients;
    }

    public void SavePatients(List<Patient> patients) 
    {
        using (StreamWriter writer = new StreamWriter("Data\\patients.txt"))
        {
            foreach (Patient patient in patients)
            {
                writer.WriteLine(
                    $"{patient.patientid},{patient.name},{patient.age},{patient.species},{patient.breed},{patient.gender},{patient.status}"
                );
            }
        }
    }

    //----------------- MEDICAL RECORDS -------------------------
    public void LoadRecords(List<Patient> patients)
    {
        if (!File.Exists("Data\\records.txt")) return;

        using (StreamReader reader = new StreamReader("Data\\records.txt")){
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] data = line.Split(',');

                int patientID = int.Parse(data[0]);

                Patient patient = patients.Find(p => p.patientid == patientID);
                if (patient == null) continue;

                RecordType type = Enum.Parse<RecordType>(data[1]);

                switch(type)
                {
                    case RecordType.Checkup:
                        patient.medicalRecords.Add(
                            new CheckupRecord (
                                int.Parse(data[2]),
                                data[3],
                                data[6],
                                data[7],
                                double.Parse(data[4]),
                                double.Parse(data[5])
                            )
                        );
                        break;
                    case RecordType.Vaccine:
                        patient.medicalRecords.Add(
                            new VaccineRecord (
                                int.Parse(data[2]),
                                data[3],
                                data[7],
                                data[8],
                                data[4],
                                data[5],
                                data[6]
                            )
                        );
                        break;
                    case RecordType.Surgery:
                        patient.medicalRecords.Add(
                            new SurgeryRecord (
                                int.Parse(data[2]),
                                data[3],
                                data[6],
                                data[7],
                                data[4],
                                data[5]
                            )
                        );
                        break;
                }
            }
        }
    }

    public void SaveRecords(List<Patient> patients)
    {
        using (StreamWriter writer = new StreamWriter("Data\\records.txt"))
        {
            foreach (Patient patient in patients)
            {
                foreach (MedicalRecord record in patient.medicalRecords)
                {
                    switch(record.recordType)
                    {
                        case RecordType.Checkup:
                            CheckupRecord c = (CheckupRecord)record;
                            writer.WriteLine (
                                $"{patient.patientid},{c.recordType},{c.recordID},{c.date},{c.weight},{c.temp},{c.diagnosis},{c.notes}"
                            );
                            break;
                        case RecordType.Vaccine:
                            VaccineRecord v = (VaccineRecord)record;
                            writer.WriteLine (
                                $"{patient.patientid},{v.recordType},{v.recordID},{v.date},{v.vaccname},{v.dose},{v.nextdue},{v.diagnosis},{v.notes}"
                            );
                            break;
                        case RecordType.Surgery:
                            SurgeryRecord s = (SurgeryRecord)record;
                            writer.WriteLine (
                                $"{patient.patientid},{s.recordType},{s.recordID},{s.date},{s.procedure},{s.recstatus},{s.diagnosis},{s.notes}"
                            );
                            break;
                    }
                }
            }
        }
    }
}