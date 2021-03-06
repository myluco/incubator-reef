/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
package org.apache.reef.runtime.common.driver.defaults;

import org.apache.reef.driver.context.ClosedContext;
import org.apache.reef.wake.EventHandler;

import javax.inject.Inject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Default event handler for ClosedContext: Logging it.
 */
public final class DefaultContextClosureHandler implements EventHandler<ClosedContext> {

  private static final Logger LOG = Logger.getLogger(DefaultContextClosureHandler.class.getName());

  @Inject
  public DefaultContextClosureHandler() {
  }

  @Override
  public void onNext(final ClosedContext closedContext) {
    LOG.log(Level.INFO, "Received ClosedContext: {0}", closedContext);
    if (closedContext.getParentContext() != null) {
      LOG.log(Level.INFO, "Closing parent context: {0}", closedContext.getParentContext().getId());
      closedContext.getParentContext().close();
    }
  }
}
