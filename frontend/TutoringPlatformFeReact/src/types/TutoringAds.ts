export interface TutoringAd{
    id: number;
    title: string;
    description: string;
    price : number;
    isOnline : boolean;
    isAvailable : boolean;

    tutorId : number;
    tutorName : string;
}