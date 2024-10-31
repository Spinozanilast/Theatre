import EventContract from '@data/event.interfaces';

export default interface EventCardModalModel {
    isModalVisible: boolean;
    event?: EventContract;
}
