export interface SuratMasuk {
    idSuratMasuk: number;
    title: string;
    regarding: string;
    toPerson: string;
    fromPerson: string;
    message: string;
    created?: Date;
}