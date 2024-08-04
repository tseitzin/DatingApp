export interface Message {
    id: number
    senderId: number
    sendUsername: string
    senderPhotoUrl: string
    recipientId: number
    recipientPhotoUrl: string
    recipientUsername: string
    content: string
    dateRead?: Date
    messageSent: Date
  }
  