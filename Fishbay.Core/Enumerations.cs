namespace Fishbay.Core
{
    public enum ProductState
    {
        None = 0,
        Created = 1,
        Enabled = 2,
        Disabled = 3,
        Deleted = 4
    }

    public enum ItemState
    {
        [Enum("Все")]
        None = 0,
        [Enum("Создан")]
        Created = 1,
        [Enum("Назначен")]
        Assigned = 2,
        [Enum("Принят")]
        Accepted = 3,
        [Enum("Добавлен")]
        Added = 4,
        [Enum("Отсутствует")]
        Missing = 5,
        [Enum("Собран")]
        Submitted = 6,
        [Enum("Подтвержден")]
        Confirmed = 7,
        [Enum("Завершен")]
        Completed = 8,
        [Enum("Приобретен")]
        Purchased = 9,
        [Enum("Собирается")]
        Picking = 10,
        [Enum("Собран")]
        Picked = 11,
        [Enum("Упаковывается")]
        Packing = 12,
        [Enum("Упакован")]
        Packed = 13,
        [Enum("Доставляется")]
        Delivering = 14,
        [Enum("Доставлен")]
        Delivered = 15,
        [Enum("Оплачен")]
        Paid = 16,
        [Enum("Неактивный")]
        Disabled = 17,
        [Enum("Отказ")]
        Rejected = 18,
        [Enum("Возврат")]
        Return = 19,
        [Enum("Отменен")]
        Cancelled = 20
    }
    public enum UserState
    {
        None = 0,
        Online = 1, // ready for accepting tasks
        Assigned = 2, // a task is assigned but no confirmation yet
        Accepted = 3, // working on task
        Offline = 4 // unready to process tasks
    }

    public enum AccountState
    {
        None = 0,
        Enabled = 1,
        Disabled = 2
    }

    

    public enum Roles
    {
        None = 0,
        Administrators = 1,
        Managers = 2,
        Picker = 3,
        Packer = 4,
        Courier = 5,
        Customers = 6
    }

    public enum InfoType
    {
        None = 0,
        PickState = 1,
        PickItem = 2
    }
}