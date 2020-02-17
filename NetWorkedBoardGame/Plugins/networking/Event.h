#ifndef EVENT_H
#define EVENT_H

enum eventType
{
	COLOR_EVENT = ID_USER_PACKET_ENUM +1,
	DIRECTION_EVENT,
	SPEED_EVENT,
	MESSAGE_EVENT
};

class Event
{
public:
	Event();
	~Event();

	virtual void executeOrder(char* message, int bufferSize) = 0;
	float getTime() {return timeStamp;}
	void setTime(int time) {timeStamp = time;}
private:

	unsigned int id;
	int timeStamp;
};

#endif // !EVENT_H