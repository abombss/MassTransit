// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Context
{
	using System;

	/// <summary>
	/// The consumer context can be used by message consumers to retrieve out-of-band information
	/// related to a message
	/// </summary>
	public interface IConsumeContext :
		IMessageContext
	{
		/// <summary>
		/// The bus on which the message was received
		/// </summary>
		IServiceBus Bus { get; }

		/// <summary>
		/// The message that was received
		/// </summary>
		object Message { get; }

		/// <summary>
		/// The object builder (container)
		/// </summary>
		IObjectBuilder Builder { get; }

		/// <summary>
		/// Send the message to the end of the input queue so that it can be processed again later
		/// </summary>
		void RetryLater();

		/// <summary>
		/// Respond to the current message, sending directly to the ResponseAddress if specified
		/// otherwise publishing the message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message">The message to send in response</param>
		void Respond<T>(T message)
			where T : class;

		/// <summary>
		/// Respond to the current message, sending directly to the ResponseAddress if specified
		/// otherwise publishing the message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message">The message to send in response</param>
		/// <param name="contextAction">The context action for specifying additional context information</param>
		void Respond<T>(T message, Action<IPublishContext> contextAction)
			where T : class;

		/// <summary>
		/// Sends the message to either the fault address if specified or publishes the fault
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="message"></param>
		void GenerateFault<T>(T message)
			where T : class;
	}
}