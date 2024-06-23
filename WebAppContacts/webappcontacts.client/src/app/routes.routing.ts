import { Routes, RouterModule } from '@angular/router';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';
import { ContactComponent } from './contact/view/contact-view/contact.component';
import { ContactAddComponent } from './contact/view/contact-add/contact-add.component';

const routes: Routes = [
  {  
    component: ContactListComponent,
    path: ""
  },
  {  
    component: ContactComponent,
    path: "contacts/:id"
  },
  {  
    component: ContactAddComponent,
    path: "contacts/add"
  },
];

export const RoutesRoutes = RouterModule.forRoot(routes);
