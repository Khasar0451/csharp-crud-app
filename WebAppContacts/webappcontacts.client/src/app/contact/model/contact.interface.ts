export interface IContact {
    id: number;
    name: string; 
    surname: string;
    email: string;
    password: string;  
    contactCategoryId: number;
    contactCategory: string;
    contactsubcategoryid: number;
    contactsubcategory: string;
    number: string;
    birthdate: Date
}
