import { Component, OnInit } from '@angular/core';
import { IContact } from '../../model/contact.interface';
import { ContactService } from '../../service/contact.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { IContactCategory } from '../../model/contactCategory.interface';
import { IContactSubcategory } from '../../model/contactSubcategory.interface';
import { NgFor, NgIf } from '@angular/common';
@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    NgFor, NgIf
  ]
})

export class ContactEditComponent implements OnInit {
  contact!: IContact
  categories!: IContactCategory[]
  subcategories!: IContactSubcategory[]
  defaultContact!: IContact;
  isLoggedIn = false
  id = 0


  constructor(private contactService: ContactService
    , private router: Router
    , private route: ActivatedRoute) { }

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
  
  patchContact(): void {
    var patchOperations = []
    
    if (this.defaultContact.name !== this.contact.name) {
      patchOperations.push({ op: 'replace', path: '/name', value: this.contact.name });
    }
    if (this.defaultContact.surname !== this.contact.surname) {
      patchOperations.push({ op: 'replace', path: '/surname', value: this.contact.surname });
    }
    if (this.defaultContact.email !== this.contact.email) {
      patchOperations.push({ op: 'replace', path: '/email', value: this.contact.email });
    }
    if (this.defaultContact.number !== this.contact.number) {
      patchOperations.push({ op: 'replace', path: '/number', value: this.contact.number });
    }
    if (this.defaultContact.password !== this.contact.password) {
      patchOperations.push({ op: 'replace', path: '/password', value: this.contact.password });
    }
    if (this.defaultContact.birthdate !== this.contact.birthdate) {
      patchOperations.push({ op: 'replace', path: '/birthdate', value: this.contact.birthdate });
    }
    if (this.defaultContact.contactCategoryId !== this.contact.contactCategoryId) {
      patchOperations.push({ op: 'replace', path: '/contactCategoryId', value: this.contact.contactCategoryId });
    }
    if (this.defaultContact.contactSubcategoryId !== this.contact.contactSubcategoryId) {
      patchOperations.push({ op: 'replace', path: '/contactsubcategoryid', value: this.contact.contactSubcategoryId });
    }
    if (this.defaultContact.contactSubcategory !== this.contact.contactSubcategory) {
      patchOperations.push({ op: 'replace', path: '/contactsubcategory', value: this.contact.contactSubcategory });
    }
    console.log(patchOperations)
    console.log(this.contact.contactSubcategory)
    this.contactService.editContact(patchOperations, this.id).subscribe(  
     () => this.router.navigate(['/contacts'])     //subscribe makes user wait for response, so they can see new data upon returning to main page
    )
  }

  ngOnInit() {
    if (localStorage.getItem('activeUser') != null){
      this.isLoggedIn = true;
    }

    this.loadCategories()
    this.loadSubcategories()

    this.route.params.subscribe(params => {
      this.id = params['id']
      this.contactService.getContact(this.id)
        .subscribe(contact => {
          this.contact = contact
          //id: id,
          //name: contact.name,
          //surname: contact.surname,
          //email: contact.email,
          //password: contact.password,
          this.defaultContact = {...this.contact}
        })
        
    });
  }

  onSubmit(): void {
    //this.contact.id = 0 //resets ID because database autoincrements it
    // this.contactService.editContact(this.patchOperations, this.id).subscribe(  
    //  () => this.router.navigate(['/contacts'])     //subscribe makes user wait for response, so they can see new data upon returning to main page
    // )
    this.patchContact()
    console.log(this.contact);
  }
}


