import { Component, Input, OnInit } from "@angular/core";
import { IContact } from "../../model/contact.interface";
import { ActivatedRoute } from "@angular/router";
import { ContactService } from "../../service/contact.service";

@Component({
  selector: 'app-contact',  //name for html tag
  templateUrl: 'contact.component.html', //displayed html 
  styleUrl: 'contact.component.css'
})
export class ContactComponent implements OnInit {
  contact!: IContact  //I'm asserting typescript that contact won't be null
  

  constructor(private service: ContactService, private route: ActivatedRoute){}
 
  ngOnInit(){
    this.route.params.subscribe(params => {
      let id:number = params['id']
      this.service.getContact(id).subscribe(
        contact => {this.contact = contact }
      )
    })
  }
}
