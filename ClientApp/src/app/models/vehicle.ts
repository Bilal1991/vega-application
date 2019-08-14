import { Model, Makes } from "./makes";
import { Contact } from "./contact";
import { Feature } from "./feature";

export interface Vehicle {
  id: number;
  model: Model;
  isRegistered: boolean;
  contact: Contact;
  lastUpdate: Date;
  make: Makes;
  feature: Feature[];



}
