import { Contact } from "./contact";

export interface SaveVehicle
{
  id: number;
  modelId: number;
  isRegisterd: boolean;
  contact: Contact;
  makeId: number;
  feature: number[];
}
