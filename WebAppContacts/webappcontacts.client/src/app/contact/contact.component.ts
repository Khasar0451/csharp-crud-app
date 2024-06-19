import { Component, Input } from "@angular/core";
import { IContact } from "../entities/contact.interface";

@Component({
  selector: 'app-contact',
  templateUrl: 'contact.component.html' 
})
export class ContactComponent {
  @Input() contact_input! : IContact
}
