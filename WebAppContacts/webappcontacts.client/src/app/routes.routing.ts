import { Routes, RouterModule } from '@angular/router';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';
import { ContactComponent } from './contact/view/contact-view/contact.component';
import { ContactAddComponent } from './contact/view/contact-add/contact-add.component';
import { ContactEditComponent } from './contact/view/contact-edit/contact-edit.component';

const routes: Routes = [
  {  
    component: ContactAddComponent,
    path: "contacts/add"
  },
  {  
    component: ContactEditComponent,
    path: "contacts/edit/:id"
  },
  {  
    component: ContactComponent,
    path: "contacts/:id"
  },
  {  
    component: ContactListComponent,
    path: "contacts"
  },
  {  
    component: ContactListComponent,
    path: ""
  },
];

export const RoutesRoutes = RouterModule.forRoot(routes);
