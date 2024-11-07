export default interface SeatContract {
    seatId: number;
    seatNumber: number;
    isOccupied: boolean;
    seatTypeMultiplier: SeatTypeMultiplier;
}

export interface SeatTypeMultiplier {
    seatType: string;
    multiplier: number;
}

export interface Sectors {
    sectorId: number;
    rows: Rows[];
}

export interface Rows {
    rowId: number;
    seats: SeatContract[];
}

export enum SeatType {
    STANDARD = 'STANDARD',
    PREMIUM = 'PREMIUM',
    PAIR = 'PAIR',
    VIP = 'VIP',
}

export interface SeatInfoModel {
    seat: SeatContract;
    sectorNumber: number;
    rowNumber: number;
}
