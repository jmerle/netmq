/*
    Copyright (c) 2007-2012 iMatix Corporation
    Copyright (c) 2009-2011 250bpm s.r.o.
    Copyright (c) 2007-2011 Other contributors as noted in the AUTHORS file

    This file is part of 0MQ.

    0MQ is free software; you can redistribute it and/or modify it under
    the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    0MQ is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace NetMQ.zmq
{
	public class Pub : XPub {

		public class PubSession : XPub.XPubSession {

			public PubSession(IOThread ioThread, bool connect,
			                  SocketBase socket, Options options, Address addr):base(ioThread, connect, socket, options, addr) {
            
			                  }

		}

		public Pub(Ctx parent, int tid, int sid):base(parent, tid, sid) {

			m_options.SocketType = ZmqSocketType.Pub;
		}

		protected override Msg XRecv(SendReceiveOptions flags)
		{
			//  Messages cannot be received from PUB socket.
			throw NetMQException.Create("Messages cannot be received from PUB socket", ErrorCode.ENOTSUP);
		}

		protected override bool XHasIn()
		{
			return false;
		}

	}
}