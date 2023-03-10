using System.Text.Json;
using static Common.PacketId;
using static Common.CommonUserState;
namespace Common;

public struct MakePacket
{ 
    public ArraySegment<byte> NotifyWait()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)PacketId.NotifyWait,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> AskAgainPossibleStartGamePacket(ushort cnt, ushort roomNumber)
    {
        PossibleStartGame possibleStartGame = new()
        {
            Count = cnt,
            RoomNumber =roomNumber
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(possibleStartGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyAskAgainPossibleGameStart,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(packetBody, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> PossibleStartGamePacket(ushort cnt, ushort roomNumber)
    {
        PossibleStartGame possibleStartGame = new()
        {
            Count = cnt,
            RoomNumber =roomNumber
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(possibleStartGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyPossibleGameStart,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(packetBody, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> VictoryPlayerPacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)VictoryPlayerResponse,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
       
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> JoinGamePacket(CommonUserState state, ushort roomId, string name)
    {
        JoinGame joinGame = new()
        {
            State = state,
            RoomId = roomId,
            UserName = name
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(joinGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyJoinGame,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> ExitPlayerReqPacket(string nickName, int roomNumber)
    {
        ExitPlayerRequest exitPlayerRequest = new()
        {
            PlayerName =  nickName,
            RoomNumber =  roomNumber,
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(exitPlayerRequest);
        var bodySize = packetBody.Length;

        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PlayerExitRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifyGameResultToSpectatorPacket(Dictionary<string, ushort> userResults)
    {
        NotifyResultGameToSpectator notifyResultGame = new()
        {
            UserResult = userResults
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(notifyResultGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyGameResultToSpectatorResponse,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifyGameResultPacket(ushort result)
    {
        NotifyResultGame notifyResultGame = new()
        {
            Result = result,
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(notifyResultGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyGameResult,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    //?????? ??????????????? ????????? ?????? ?????? ???
    public ArraySegment<byte> NoifyAttackAgainPacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyAttackAgain,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> StartGameReqPacket(string? result, ushort count, ushort roomNumber)
    {
        StartGameRequest startGameRequest = new()
        {
            Result = result,
            UserCount = count,
            RoomNumber = roomNumber
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(startGameRequest);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.StartGameRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifyLooserPacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyLooser,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifyConvertUserState()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyConvertState,
        };

        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
       
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        
        return segment;
    }
    
    public ArraySegment<byte> NotifyExitPacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyExit,
        };

        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
       
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }

    public ArraySegment<byte> NewHostPacket(ushort roomId)
    {
        NewHost newHost = new()
        {
            RoomId = roomId
        };
        var bodyPacket =JsonSerializer.SerializeToUtf8Bytes(newHost);
        var bodySize = bodyPacket.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)NotifyNewhost,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(bodyPacket, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, bodySize);
        }
        return segment;
    }

    public ArraySegment<byte> PossibleGameRequestPacket(ushort roomId)
    {
        PossibleGame possibleGame = new()
        {
            RoomId = roomId
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(possibleGame);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.PossibleGame,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(packetBody, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, bodySize);
        }
        return segment;
    }
    
    public ArraySegment<byte> AttackReqPacket(string nickname, string attackValue)
    {
        AttackRequest attackRequest = new()
        {
            Nickname = nickname,
            Value = attackValue
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(attackRequest);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.AttackRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifySpectateGamePacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyGameSpectate,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);

        var segment = new ArraySegment<byte>(new byte[4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        
        return segment;
    }
    
    public ArraySegment<byte> NotifyStartGamePacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyGameStart,
        };
        
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);

        var segment = new ArraySegment<byte>(new byte[4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        
        return segment;
        
    }

    public ArraySegment<byte> ReadyResPacket(bool isReady)
    {
        ReadyResponse readyResponse = new()
        {
            ReadyResult = isReady
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(readyResponse);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.ReadyResponse,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> JoinGameRequestPacket(string nickName)
    {
        JoinGameRequest joinGameRequest = new()
        {
            NickName = nickName
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(joinGameRequest);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.JoinGameRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        
        return segment;
    }

    //todo : ????????? ???.. 
    public ArraySegment<byte> ExitRoom(int roomNumber, string name)
    {
        ExitRoomRequest exitRoomRequest = new()
        {
            RoomNumber = roomNumber,
            Name = name
        };
        
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(exitRoomRequest);
        var bodySize = packetBody.Length;
        
        
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)PacketId.ExitRoom,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(packetBody, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, bodySize);
        }
        return segment;
    }
    
    public ArraySegment<byte> ReadyReqPacket(string readyState, string nickName, int roomId)
    {
        ReadyRequest readyRequest = new()
        {
            ReadyState = readyState,
            NickName = nickName,
            RoomId = roomId
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(readyRequest);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.ReadyRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[packetBody.Length + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    public ArraySegment<byte> NotifyReadyPacket(ushort roomId)
    {
        NotifyReady notifyReady = new()
        {
            RoomId = roomId
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(notifyReady);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.NotifyReady,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);

        var segment = new ArraySegment<byte>(new byte[bodySize + buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    
    public ArraySegment<byte> NotEixtRoomNumberPacket()
    {
        Packet packet = new()
        {
            Size = 4,
            Id = (ushort)NotifyNotExist,
        };

        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[buffer.Length + buffer2.Length]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        }
        return segment;
    }
    public ArraySegment<byte> EnterRoomResToHostPacket(int room)
    {
        EnterRoomToHostResponse enterRoomToHostResponse = new()
        {
            RoomNumber = room,
            UserState = Host,
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(enterRoomToHostResponse);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)EnterHostResponse,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);

        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }
    //room status..-> ?????? ????????? ????????? ?????? ready??? ??????????????? ????????? ????????? ??? ?????? 
    // -> ??????????????? ????????? ?????? ??????????????? 
    public ArraySegment<byte> EnterRoomResPacket(int room, ushort userState)
    {
        if (room == -1)
            room = 1;

        CommonUserState commonState = new();
        //??? ??? ??? ??? todo : ?????? ! 
        switch (userState)
        {
            case var state  when state ==  8:
                commonState = Ready;
                break;
            case var state  when state == 7:
                commonState = Host;
                break;
            case var state  when state == 6 :
                commonState = Spectator;
                break;
        }
        
        EnterRoomResponse enterRoomResponse = new()
        {
            RoomNumber = room,
            UserState =  commonState
        };
        var body = JsonSerializer.SerializeToUtf8Bytes(enterRoomResponse);
        var bodySize = body.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.EnterRoomResponse,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        

        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(body, 0, segment.Array, segment.Offset + buffer.Length + buffer2.Length, body.Length);
        }
        return segment;
    }

    public ArraySegment<byte> EnterRoomReqPacket(string nickName, short roomNumber)
    {
        EnterRoomRequest enterRoomRequest = new()
        {
            NickName = nickName,
            RoomNmber = roomNumber,
        };
        var packetBody = JsonSerializer.SerializeToUtf8Bytes(enterRoomRequest);
        var bodySize = packetBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.EnterRoomRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array != null)
        {
            Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
            Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
            Array.Copy(
                packetBody, 0, segment.Array,
                segment.Offset + buffer.Length + buffer2.Length, packetBody.Length);
        }
        return segment;
    }

    
    public ArraySegment<byte> ShowRoomResPacket(List<Room> roomInfo)
    {
        ShowRoomResponse showRoomResponse = new()
        {
            RooomInfo = roomInfo
        };
        var roomBody = JsonSerializer.SerializeToUtf8Bytes(showRoomResponse);
        var bodySize = roomBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.ShowRoomResponse,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var segment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (segment.Array == null)
            return segment;

        Array.Copy(buffer, 0, segment.Array, segment.Offset, buffer.Length);
        Array.Copy(buffer2, 0, segment.Array, segment.Offset + buffer.Length, buffer2.Length);
        Array.Copy(
            roomBody, 0, segment.Array,
            segment.Offset + buffer.Length + buffer2.Length, roomBody.Length);
        return segment;
    }

    public ArraySegment<byte> ShowRoomReqPacket(string nickName)
    {
        ShowRoomRequest showRoomRequest = new()
        {
            NickName = nickName
        };
        var verifyIdBody = JsonSerializer.SerializeToUtf8Bytes(showRoomRequest);
        var bodySize = verifyIdBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)PacketId.ShowRoomRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        
        var verifySegment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (verifySegment.Array == null)
            return verifySegment;

        Array.Copy(buffer, 0, verifySegment.Array, verifySegment.Offset, buffer.Length);
        Array.Copy(buffer2, 0, verifySegment.Array, verifySegment.Offset + buffer.Length, buffer2.Length);
        Array.Copy(
            verifyIdBody, 0, verifySegment.Array,
            verifySegment.Offset + buffer.Length + buffer2.Length, verifyIdBody.Length);
        return verifySegment;
    }

    public ArraySegment<byte> VerifyPlayerId(string playerNickName)
    {
        VerifyIdRequest verifyIdRequest = new()
        {
            NickName = playerNickName
        };
        var verifyIdBody = JsonSerializer.SerializeToUtf8Bytes(verifyIdRequest);
        var bodySize = verifyIdBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)VerifyPlayerRequest,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var verifySegment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (verifySegment.Array == null)
            return verifySegment;

        Array.Copy(buffer, 0, verifySegment.Array, verifySegment.Offset, buffer.Length);
        Array.Copy(buffer2, 0, verifySegment.Array, verifySegment.Offset + buffer.Length, buffer2.Length);
        Array.Copy(
            verifyIdBody, 0, verifySegment.Array,
            verifySegment.Offset + buffer.Length + buffer2.Length, verifyIdBody.Length);

        return verifySegment;
    }

    public ArraySegment<byte> VerifyPlayerIdResPacket(bool isPass)
    {
        VerifyIdResponse verifyIdResponse = new()
        {
            IsOk = isPass
        };
        var verifyIdBody = JsonSerializer.SerializeToUtf8Bytes(verifyIdResponse);
        var bodySize = verifyIdBody.Length;
        
        Packet packet = new()
        {
            Size = (ushort)(bodySize + 4),
            Id = (ushort)VerifyPlayerResponse,
        };
        var buffer = BitConverter.GetBytes(packet.Size);
        var buffer2 = BitConverter.GetBytes(packet.Id);
        
        var verifySegment = new ArraySegment<byte>(new byte[bodySize + 4]);
        if (verifySegment.Array == null)
            return verifySegment;

        Array.Copy(buffer, 0, verifySegment.Array, verifySegment.Offset, buffer.Length);
        Array.Copy(buffer2, 0, verifySegment.Array, verifySegment.Offset + buffer.Length, buffer2.Length);
        Array.Copy(
            verifyIdBody, 0, verifySegment.Array,
            verifySegment.Offset + buffer.Length + buffer2.Length, verifyIdBody.Length);
        return verifySegment;
    }
}