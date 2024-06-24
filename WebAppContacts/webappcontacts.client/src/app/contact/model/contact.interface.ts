export interface IContact {
    id: number;
    name: string; 
    surname: string;
    email: string;
    password: string;  
    contactCategoryId: number;
    contactCategory: string;
    contactSubcategoryId: number;
    contactSubcategory: string;
    number: string;
    birthdate: Date
}
