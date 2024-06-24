import { Component, OnInit } from '@angular/core';
import { IContact } from '../../model/contact.interface';
import { ContactService } from '../../service/contact.service';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { IContactCategory } from '../../model/contactCategory.interface';
import { IContactSubcategory } from '../../model/contactSubcategory.interface';
import { NgFor, NgIf } from '@angular/common';
@Component({
  selector: 'app-contact-add',
  templateUrl: './contact-add.component.html',
  styleUrls: ['./contact-add.component.css'],
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    NgFor, NgIf
  ]
})

export class ContactAddComponent implements OnInit {
  contact!: IContact
  categories!: IContactCategory[]
  subcategories!: IContactSubcategory[]
  constructor(private contactService: ContactService, private router: Router) { }

  loadCategories(): void {
    this.contactService.getContactsCategories().subscribe(
      (cat: IContactCategory[]) => {
        this.categories = cat
      }
    );
  }

  loadSubcategories(): void {
    this.contactService.getContactsSubcategories().subscribe(
      (subcat: IContactSubcategory[]) => {
        this.subcategories = subcat
      }
    );
  }

  ngOnInit() {
    this.loadCategories()
    this.loadSubcategories()
    this.contact = {
      id: 0,
      name: "",
      surname: "",
      email: "",
      password: "",
      contactCategoryId: 0,
      contactCategory: "",
      contactSubcategoryId: 0,
      contactSubcategory: "",
      number: "",
      birthdate: new Date(0)
    };
  }

  onSubmit(): void {
    //this.cotactService.addContact(this.contact!). subscribe(  
    //  () => this.router.navigate(['/contacts'])     //subscribe makes user wait for response, so they can see new data upon returning to main page
    //)
    console.log(this.contact);
  }
}


