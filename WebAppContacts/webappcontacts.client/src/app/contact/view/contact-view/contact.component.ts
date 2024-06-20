import { Component, Input, OnInit } from "@angular/core";
import { IContact } from "../../model/contact.interface";
import { ActivatedRoute } from "@angular/router";
import { ContactService } from "../../service/contact.service";

@Component({
  selector: 'app-contact',  //name for html tag
  templateUrl: 'contact.component.html' //displayed html 
})
export class ContactComponent implements OnInit {
  @Input() contact_input! : IContact  
  contact!: IContact  //I'm asserting typescript that contact won't be null
  id!:number;

  constructor(private service: ContactService, private route: ActivatedRoute){}
 
  ngOnInit(){
    this.route.params.subscribe(params => {
      this.id = params['id']
      // this.service.getContact(params['id'])
      // .subscribe(contact => this.contact = contact)
    })
  }
}
