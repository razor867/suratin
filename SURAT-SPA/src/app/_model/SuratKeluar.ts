export interface SuratKeluar {
    idSuratKeluar: number;
    title: string;
    noLetter: string;
    regarding: string;
    toPerson: string;
    fromPerson: string;
    message: string;
    created?: Date;
}